using Blog.DAL.Infrastructure;
using TDD.DbTestHelpers.Yaml;

namespace Blog.DAL.Tests
{
    public class BlogFixtures : YamlDbFixture<BlogContext, BlogFixturesModel>
    {
        public BlogFixtures()
        {
            SetYamlFiles("Posts.yml");
        }
    }
}
