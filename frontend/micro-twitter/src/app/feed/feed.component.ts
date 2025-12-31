import { Component } from '@angular/core';
import { PostsService } from '../services/posts.service';
import { Post } from '../models/post.model';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css']
})
 export class FeedComponent {

  posts: Post[] = [];
  newPostContent = '';
  currentUser = 'aleksandra';
  pageIndex=0;
  pageSize=10;
  totalCount=0;

  constructor(private postsService: PostsService) {}

  ngOnInit(): void {
    this.loadPosts();
  }


  loadPosts(): void {
    this.postsService
      .getAllPosts(this.pageIndex + 1, this.pageSize)
      .subscribe(res => {
        this.posts = res.items;
        this.totalCount = res.totalCount;
      });
  }

  next(): void {
    this.pageIndex++;
    this.loadPosts();
  }

  prev(): void {
    if (this.pageIndex > 0) {
      this.pageIndex--;
      this.loadPosts();
    }
  }

  isLastPage(): boolean {
    return (this.pageIndex + 1) * this.pageSize >= this.totalCount;
  }

  createPost(): void {
    if (this.newPostContent.length < 12 || this.newPostContent.length > 140) {
      return;
    }

    this.postsService.createPost(this.newPostContent).subscribe(() => {
      this.newPostContent = '';
      this.loadPosts();
    });
  }

  deletePost(id: string): void {
    this.postsService.deletePost(id).subscribe(() => {
      this.loadPosts();
    });
  }
}
