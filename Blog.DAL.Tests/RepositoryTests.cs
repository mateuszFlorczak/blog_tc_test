﻿using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using Blog.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using TDD.DbTestHelpers.Yaml;
using TDD.DbTestHelpers.Core;

namespace Blog.DAL.Tests
{
    public class BlogFixturesModel
    {
        public FixtureTable<Post> Posts { get; set; }
        public FixtureTable<Comment> Comments { get; set; }
    }
    public class BlogFixtures : YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            SetYamlFiles("Posts.yml");
        }
    }
    [TestClass]
    public class RepositoryTests : DbBaseTest<BlogFixtures>
    {
        [TestMethod]
        public void GetAllPost_OnePostInDb_ReturnOnePost()
        {
            // arrange
            var context = new BlogContext();
            context.Database.CreateIfNotExists();
            //context.Posts.ToList().ForEach(x => context.Posts.Remove(x));
            //context.Posts.Add(new Post
            //{
            //    Author = "test",
            //    Content = "test, test, test..."
            //});
            //context.SaveChanges();
            var repository = new BlogRepository();
            // act
            var result = repository.GetAllPosts();
            // assert
            Assert.AreEqual(1, result.Count());
            var post = new Post();
            post.Author = "ja";
            post.Content = "pusto";
            repository.AddNewPost(post);

            Assert.AreEqual(2, result.Count());

            Comment comment = new Comment();
            comment.Content = "wtfcomment";
            repository.AddNewCommentToPost(comment, post);
            var commentsResult = repository.GetAllComments();

            Assert.AreEqual(2, commentsResult.Count());

            var commentsForPostResult = repository.GetAllCommentsForPost(post);

            Assert.AreEqual(1, commentsForPostResult.Count());
            
        }
    }
}
