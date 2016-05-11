using System.Collections.Generic;
using Blog.DAL.Infrastructure;
using Blog.DAL.Model;
using System;

namespace Blog.DAL.Repository
{
    public class BlogRepository
    {
        private readonly BlogContext _context;

        public BlogRepository()
        {
            _context = new BlogContext();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts;
        }

        public void AddNewPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void AddNewCommentToPost(Comment comment, Post post)
        {
            comment.PostId = post.Id;
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public IEnumerable<Comment> GetAllComments()
        {
            return _context.Comments;
        }

        public IEnumerable<Comment> GetAllCommentsForPost(Post post)
        {
            List<Comment> comments = new List<Comment>();
            foreach(Comment comment in _context.Comments)
            {
                if (comment.PostId.Equals(post.Id))
                    comments.Add(comment);
            }
            return comments;
        }
    }
}
