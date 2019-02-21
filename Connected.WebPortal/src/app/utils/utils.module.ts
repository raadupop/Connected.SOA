import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TagsInputComponent } from './tags-input/tags-input.component';
import { TagsInputCoreComponent } from "./tags-input/tags-input-core.component";

@NgModule({
  declarations: [
    TagsInputComponent,
    TagsInputCoreComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    TagsInputComponent,
		TagsInputCoreComponent
  ]
})
export class UtilsModule { }
