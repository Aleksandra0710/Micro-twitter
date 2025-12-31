import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FeedComponent } from './feed/feed.component';
import { MyProfileComponent } from './my-profile/my-profile.component'; 
const routes: Routes =
[
  { path: 'feed', component: FeedComponent, title: "Twitter-Main Page" },
  { path: 'profile', component: MyProfileComponent, title: "Twitter-My profile" },
  { path: '', redirectTo: '/feed', pathMatch: 'full' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
