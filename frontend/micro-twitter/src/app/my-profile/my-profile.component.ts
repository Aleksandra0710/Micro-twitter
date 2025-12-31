import { Component } from '@angular/core';
import { Post } from '../models/post.model';
import { PostsService } from '../services/posts.service';

@Component({
  selector: 'app-my-profile',
  templateUrl: './my-profile.component.html',
  styleUrls: ['./my-profile.component.css']
})
export class MyProfileComponent {
  posts: Post[] = [];
  pageIndex = 0;
  pageSize = 10;
  totalCount = 0;

  constructor(private postsService: PostsService) { }


  ngOnInit(): void {
    this.loadMyPosts();
  }

  loadMyPosts(): void {
    this.postsService
      .getMyPosts(this.pageIndex + 1, this.pageSize)
      .subscribe(res => {
        this.posts = res.items;
        this.totalCount = res.totalCount;
      });
  }

  next(): void {
    this.pageIndex++;
    this.loadMyPosts();
  }

  prev(): void {
    if (this.pageIndex > 0) {
      this.pageIndex--;
      this.loadMyPosts();
    }
  }

  isLastPage(): boolean {
    return (this.pageIndex + 1) * this.pageSize >= this.totalCount;
  }
  deletePost(id: string) {
    this.postsService.deletePost(id).subscribe(() => {
      this.posts = this.posts.filter(p => p.id !== id);
    });
  }
}

