import { Component, Input, Output, EventEmitter } from '@angular/core';
import { Post } from '../models/post.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent {

  @Input() post!: Post;
  @Input() canDelete = false;

  @Output() delete = new EventEmitter<string>();

  onDelete() {
    this.delete.emit(this.post.id);
  }
}
