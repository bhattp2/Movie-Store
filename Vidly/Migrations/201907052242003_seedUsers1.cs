namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers1 : DbMigration
    {
        public override void Up()
        {
            Sql(@" 
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'01076939-cb86-4ce6-b523-d91857d25f5d', N'admin@vidly.com', 0, N'AJlf6eRGPq97W1l85WfbwN35Z4OW2WunJaGH7t1yPYvGVLELDz0qR4276YPxVXHJjg==', N'0690deff-b151-45d4-87c6-cf46ee7a78b8', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'91c34a31-b7c4-4be5-8276-54d3c5c1ec9b', N'guest@vidly.com', 0, N'APi/v8vzZ7s/NonfEth+Qqu6BAxvtYTlacDfIMp0TzSexR5WVq3Re+ItkQQfzswYcw==', N'092cd897-fc06-42b2-bd86-e41b497329ec', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'cde19a93-80ed-4076-8b43-bc6b0a21d928', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'01076939-cb86-4ce6-b523-d91857d25f5d', N'cde19a93-80ed-4076-8b43-bc6b0a21d928')

");
                
        }
        
        public override void Down()
        {
        }
    }
}
