using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MockContext
    {
        public MockContext()
        {
            AspNetUser aspNetUser1 = new AspNetUser() { Id = "guid111", UserName = "sasha" };
            AspNetUser aspNetUser2 = new AspNetUser() { Id = "guid222", UserName = "sasha" };

            User user1 = new User() { Id = 1, Email = "sasha@gm.ua", Photo = "path/", AvailableLikes = 2, AddingCount = 1, AspNetUser = aspNetUser1 };
            User user2 = new User() { Id = 1, Email = "oleg@gm.ua", Photo = "path/", AvailableLikes = 1, AddingCount = 1, AspNetUser = aspNetUser2 };

            Video video1 = new Video() { Id = 1, Title = "Crying", CreatedDate = DateTime.Now, Views = 101, Likes = 6, Url = "path/", User = user1 };
            Video video2 = new Video() { Id = 2, Title = "Crying", CreatedDate = DateTime.Now, Views = 101, Likes = 6, Url = "path/", User = user2 };

            Comment comment1 = new Comment() { Id = 1, CreatedDate = DateTime.Now, Text = "Super)))", User = user1, Video = video1 };
            Comment comment2 = new Comment() { Id = 2, CreatedDate = DateTime.Now, Text = "Not bad!!", User = user1, Video = video2 };

            video1.Comments.Add(comment1);
            video2.Comments.Add(comment2);

            user1.Videos.Add(video1);
            user2.Videos.Add(video2);

            user1.Comments.Add(comment1);
            user2.Comments.Add(comment2);            

            this.AspNetUsers = new List<AspNetUser>() { aspNetUser1, aspNetUser2 };
            this.Users = new List<User>() { user1, user2 };
            this.Videos = new List<Video>() { video1, video2 };
            this.Comments = new List<Comment>() { comment1, comment2 };
        }

        public List<AspNetUser> AspNetUsers { get; set; }
        public List<User> Users { get; set; }
        public List<Video> Videos { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
