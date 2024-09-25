namespace KingbaseES.BasicTest;

internal static class Program
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddDbContext<BlogContext>(options =>
        {
            options.UseKdbndp(@"host=localhost;port=54321;database=test;user id=system;password=123456;");   
        });

        var serviceProvider = services.BuildServiceProvider();

        var context = serviceProvider.GetRequiredService<BlogContext>();

        context.Database.EnsureCreated();

        // get list
        var blogs = context.Blogs.ToList();
        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "当前 Blogs 表中条目数：" + blogs.Count);
        if (blogs.Any())
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "当前 Blogs 表中条目数大于1，进行清理...");
            context.Blogs.RemoveRange(blogs);
            context.SaveChanges();
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "清理完成！");
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "当前 Blogs 表中条目数：" + blogs.Count);
        }
        var authors = context.Authors.ToList();
        if (authors.Any())
        {
            context.Authors.RemoveRange(authors);
            context.SaveChanges();
        }
        //add
        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "新增 Blog 实体 值为I love EFCore!");
        var author = new Author() { BirthTime = DateTime.Parse("2000/09/10"), Name = "Li" };

        context.Add(new Blog() { Name = "I love EFCore!" ,CreatedDateTime = DateTime.Now, Author = author });
        var result = context.SaveChanges();

        //update
        var first = context.Blogs.FirstOrDefault();
        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "查询结果:" + first.Name);

        Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "变更 Blog 实体 值为I love EFCore too!");
        first.Name = "I love EFCore too!";
        context.SaveChanges();

        // get
        var query = (from b in context.Blogs
             group b by new
             {
                 b.Name,
                 BirthYearMonth = new {b.Author.BirthTime.Year,b.Author.BirthTime.Month}
             }
             into g
             select new
             {
                 NamedBirth = g.Key,
                 BlogCount = g.Count()
             })
            .ToList();
       
        Console.ReadKey();
    }
}
