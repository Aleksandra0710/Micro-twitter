import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../models/post.model';
import { catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PostsPerPage } from '../models/post-per-page';
@Injectable({
  providedIn: 'root'
})
export class PostsService {

  private apiUrl=environment.apiUrl + '/api/posts';

  constructor(private http: HttpClient) {}

  getAllPosts(page:number,pageSize:number) {
    return this.http.get<PostsPerPage<Post>>(
      `${this.apiUrl}?page=${page}&pageSize=${pageSize}`);
  }

  createPost(content: string): Observable<void> {
    return this.http.post<void>(this.apiUrl, { content });
  }
  getMyPosts(page:number,pageSize:number) {
    return this.http.get<PostsPerPage<Post>>(
      `${this.apiUrl}/mine?page=${page}&pageSize=${pageSize}`);
  }
 deletePost(id: string): Observable<void> {
  return this.http.delete<void>(`${this.apiUrl}/${id}`)
    .pipe(
      catchError(error => {
        return throwError(() => error);
      })
    );
}
}
