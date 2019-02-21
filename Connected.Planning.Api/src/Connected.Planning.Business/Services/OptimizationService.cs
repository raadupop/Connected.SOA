using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Connected.Planning.Domain.Planning;
using Connected.Planning.Domain.Planning.Dto;
using Connected.Planning.Domain.Planning.GeneticAlgorithm;
using GAF;
using GAF.Extensions;
using GAF.Operators;

namespace Connected.Planning.Business.Services
{
    public class OptimizationService : IOptimizationService
    {
        private readonly IPlanningRepository _planningRepository;

        public OptimizationService(IPlanningRepository planningRepository)
        {
            _planningRepository = planningRepository;
        }

        private static PersonalPlanDto PersonalPlan { get; set; }

        public void OptimizeStrategicPlan(PersonalPlanDto personalPlan)
        {
            PersonalPlan = personalPlan;

            var population = new Population();

            for (var p = 0; p < 20; p++)
            {
                var chromosome = new Chromosome();
                foreach (var activitySlotDto in personalPlan.Activities)
                {
                    chromosome.Genes.Add(new Gene(activitySlotDto));
                }

                chromosome.Genes.ShuffleFast();
                population.Solutions.Add(chromosome);
            }

            // create the elite operator
            var elite = new Elite(10);

            // create the crossover operator
            var crossover = new Crossover(0.8)
            {
                CrossoverType = CrossoverType.DoublePointOrdered
            };

            // create the mutation operator
            var mutate = new SwapMutate(0.02);

            // create the GA
            var ga = new GeneticAlgorithm(population, CalculateFitness);

            // hook up to some useful events
            ga.OnGenerationComplete += ga_OnGenerationComplete;
            ga.OnRunComplete += ga_OnRunComplete;

            // add the operators
            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutate);

            // run the GA
            ga.Run(Terminate);
        }

        private static bool Terminate(Population population, int currentGeneration, long currentEvaluation)
        {
            return currentGeneration > 30;
        }

        private static double CalculateFitness(Chromosome chromosome)
        {
            var score = 0.0;
            var feasibleActivities = RemoveUnfeasibleActivities(chromosome);

            foreach (var activity in feasibleActivities)
            {
                score += 1.0 / activity.Priority; 
            }

            var finalScore = score / PersonalPlan.Activities.Count;

            return (float)finalScore;
        }


        /// <summary>
        /// Remove unfeasible solution based on the constraint 
        /// </summary>
        /// <param name="chromosome"></param>
        /// <returns>A chromosome that contains only satisfied solution</returns>
        private static IEnumerable<ActivityPlanEntryDto> RemoveUnfeasibleActivities(Chromosome chromosome)
        {
            var planFreeTimeSpan = PersonalPlan.FreeTimeEndsOn - PersonalPlan.FreetimeStartsOn;
            var planInception = PersonalPlan.PlanStartsOn;
            var toalTimeAvailable =
                planFreeTimeSpan * ((PersonalPlan.PlanEndsOn - PersonalPlan.PlanStartsOn).TotalDays + 1);

            var timeLeft = toalTimeAvailable;
            var filtredActivity = new List<ActivityPlanEntryDto>();

            foreach (var gene in chromosome.Genes.ToList())
            {
                var currentActivity = (ActivityPlanEntryDto)gene.ObjectValue;
                var timeLimits = (currentActivity.ActivityDeadline - planInception).TotalDays + 1;
                var deadlineTimeSpan = planFreeTimeSpan * timeLimits;
                if (currentActivity.TimeAllocation <= deadlineTimeSpan &&
                    (toalTimeAvailable - deadlineTimeSpan) <= (timeLeft - currentActivity.TimeAllocation))
                {
                    timeLeft -= currentActivity.TimeAllocation;
                    filtredActivity.Add(currentActivity);
                }
            }

            return filtredActivity;
        }

        private void ga_OnRunComplete(object sender, GaEventArgs e)
        {
            var fittest = e.Population.GetTop(1)[0];
            var feasibleActivities = RemoveUnfeasibleActivities(fittest);

            ScheduleActivities(feasibleActivities);
        }

        /// <summary>
        /// Fulfill the schedule entries 
        /// </summary>
        /// <param name="activities"></param>
        public void ScheduleActivities(IEnumerable<ActivityPlanEntryDto> activities)
        {
            var scheduleTemplate = new ScheduleTemplateDto()
            {
                Name = "Automated Schedule Template",
                PersonalPlanId = PersonalPlan.Id,
                OptimizationModel = new ScheduleOptimizationType()
                {
                    Classification = OptimizationModel.InteligentSchedule,
                    Name = "Intelligent Automation Schedule"
                },
                ScheduleActivities = new List<ScheduleEventDto>()
            };

            // Timespan indicative
            var transientDateProgression = new DateTime(PersonalPlan.PlanStartsOn.Year, PersonalPlan.PlanStartsOn.Month, PersonalPlan.PlanStartsOn.Day, PersonalPlan.FreetimeStartsOn.Hours, PersonalPlan.FreetimeStartsOn.Minutes, 0);
            var dailyFreeTimeSpan = PersonalPlan.FreeTimeEndsOn - PersonalPlan.FreetimeStartsOn;
        
            foreach (var activity in activities)
            {
                var activityRemainingTime = activity.TimeAllocation;

                // Brake down full timespan activities (ex: [x,y])
                while (activityRemainingTime >= dailyFreeTimeSpan)
                {
                    scheduleTemplate.ScheduleActivities.Add(new ScheduleEventDto
                    {
                        Name = activity.Name,
                        Description = activity.Description,
                        StartsOn = new DateTime(PersonalPlan.PlanStartsOn.Year, transientDateProgression.Month, transientDateProgression.Day, transientDateProgression.Hour, transientDateProgression.Minute, 0),
                        EndsOn = new DateTime(PersonalPlan.PlanStartsOn.Year, transientDateProgression.Month, transientDateProgression.Day, PersonalPlan.FreeTimeEndsOn.Hours, PersonalPlan.FreeTimeEndsOn.Minutes, 0),
                    });

                    // Timespan already scheduled above
                    var timespanScheduled = PersonalPlan.FreeTimeEndsOn.Subtract(transientDateProgression.TimeOfDay);

                    // Subtract time allocation
                    activityRemainingTime -= timespanScheduled;
                    
                    // Move on to the next day
                    transientDateProgression = transientDateProgression.AddDays(1.0);

                    // Overflow case so get back on the free time starts
                    if (!activityRemainingTime.Equals(TimeSpan.Zero))
                    {
                        transientDateProgression -= timespanScheduled;
                    }
                }

                // Brake down partial timespan activities (ex: [x+2, y])
                while (activityRemainingTime < dailyFreeTimeSpan && activityRemainingTime > TimeSpan.Zero)
                {
                    // maximum timespan that can be added
                    var feasibleTimeToAdd = PersonalPlan.FreeTimeEndsOn.Subtract(transientDateProgression.TimeOfDay);

                    if (activityRemainingTime <= feasibleTimeToAdd)
                    {
                        scheduleTemplate.ScheduleActivities.Add(new ScheduleEventDto
                        {
                            Name = activity.Name,
                            Description = activity.Description,
                            StartsOn = new DateTime(PersonalPlan.PlanStartsOn.Year, transientDateProgression.Month, transientDateProgression.Day, transientDateProgression.Hour, transientDateProgression.Minute, 0),
                            EndsOn = new DateTime(PersonalPlan.PlanStartsOn.Year, transientDateProgression.Month, transientDateProgression.Day, transientDateProgression.Add(activityRemainingTime).Hour, transientDateProgression.Add(activityRemainingTime).Minute, 0),
                        });

                        transientDateProgression = transientDateProgression.Add(activityRemainingTime);
                        activityRemainingTime -= activityRemainingTime;
                    }
                    else
                    {
                        scheduleTemplate.ScheduleActivities.Add(new ScheduleEventDto
                        {
                            Name = activity.Name,
                            Description = activity.Description,
                            StartsOn = new DateTime(PersonalPlan.PlanStartsOn.Year, transientDateProgression.Month, transientDateProgression.Day, transientDateProgression.Hour, transientDateProgression.Minute, 0),
                            EndsOn = new DateTime(PersonalPlan.PlanStartsOn.Year, transientDateProgression.Month, transientDateProgression.Day, feasibleTimeToAdd.Hours, feasibleTimeToAdd.Minutes, 0),
                        });

                        transientDateProgression = transientDateProgression.Add(feasibleTimeToAdd);
                        activityRemainingTime -= feasibleTimeToAdd;
                    }

                    // Move on to the next day at the start free time point
                    if (transientDateProgression.TimeOfDay.Equals(PersonalPlan.FreeTimeEndsOn))
                    {
                        transientDateProgression = transientDateProgression.AddDays(1.0).Subtract(dailyFreeTimeSpan);
                    }
                }
            }

            _planningRepository.CreateScheduleTemplate(scheduleTemplate);
        }

        private static void ga_OnGenerationComplete(object sender, GaEventArgs e)
        {
            var fittest = e.Population.GetTop(1)[0];

            Debug.WriteLine("Generation: {0}, Fitness: {1}", e.Generation, fittest.Fitness);
        }
    }
}
