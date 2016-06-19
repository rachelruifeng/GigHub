namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFollowing1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers");
            RenameColumn(table: "dbo.Followings", name: "ArtistId", newName: "FollowerId");
            RenameColumn(table: "dbo.Followings", name: "UserId", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_UserId", newName: "IX_FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_ArtistId", newName: "IX_FollowerId");
            AddForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Followings", "FolloweeId", "dbo.AspNetUsers");
            RenameIndex(table: "dbo.Followings", name: "IX_FollowerId", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "UserId");
            RenameColumn(table: "dbo.Followings", name: "FollowerId", newName: "ArtistId");
            AddForeignKey("dbo.Followings", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
