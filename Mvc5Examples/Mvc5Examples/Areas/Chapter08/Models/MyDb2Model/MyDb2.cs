namespace Mvc5Examples.Areas.Chapter08.Models.MyDb2Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class MyDb2 : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“MyDb2”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“Mvc5Examples.Areas.Chapter08.Models.MyDb2Model.MyDb2”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“MyDb2”
        //连接字符串。

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public MyDb2()
            : base("name=MyDb2")
        {
            //调试用（通过输出窗口观察数据库操作的内容）
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        public virtual DbSet<MyTable1> MyTable1 { get; set; }
        public virtual DbSet<MyTable2> MyTable2 { get; set; }
        public virtual DbSet<MyTable3> MyTable3 { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTable1>()
                .Property(e => e.KeChengID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable1>()
                .HasMany(e => e.MyTable3)
                .WithRequired(e => e.MyTable1)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MyTable2>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable2>()
                .HasMany(e => e.MyTable3)      //MyTable2中的1行对应MyTable3中的多行
                .WithRequired(e => e.MyTable2) //MyTable3中的学号在MyTable2中必须存在
                                               //?启用级联删除（删除MyTable2中的记录时自动删除MyTable3中对应的所有记录）
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<MyTable3>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<MyTable3>()
                .Property(e => e.KeChengID)
                .IsFixedLength();
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}