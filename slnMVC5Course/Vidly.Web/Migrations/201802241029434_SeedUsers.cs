namespace Vidly.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'11a60139-20d8-4131-a936-b26b147cf5e5', N'luisferop@gmail.com', 0, N'ALSeNdvNTKOxD93A2MPVbdFV71IfORxif+RuFT2C3MrC0GjS3dEndmWOl0Y2eCLAHA==', N'827529f5-943b-4055-b7de-fe445aa72b2e', NULL, 0, 0, NULL, 1, 0, N'luisferop@gmail.com')
                    INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'154b9506-3b42-43db-b3aa-95160c8c6abf', N'guest@guest.com', 0, N'AJkLCx1kJdLxPMaOm2x9zQZEc5HXeoradRhD/LSQc+IF22mqRI88lQk6IKpUNYKGyg==', N'6b7de475-8b7e-4f3a-a947-e7250abeb765', NULL, 0, 0, NULL, 1, 0, N'guest@guest.com')
                    INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'f1587715-3707-4876-aa2b-712e5c394ba3', N'admin@vidly.com', 0, N'AB+HeAKKAMS+2UUSo5sL2dJF1DflTkIllYqk/zRV0T3ejs9Yc057sFPNmM5AaPdKxA==', N'6a68bd56-5b8f-4995-9566-089923f19157', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'40c0e451-2c68-497f-acb8-f1beb24bebe1', N'CAnManageMovie')

                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f1587715-3707-4876-aa2b-712e5c394ba3', N'40c0e451-2c68-497f-acb8-f1beb24bebe1')");
        }
        
        public override void Down()
        {
        }
    }
}
