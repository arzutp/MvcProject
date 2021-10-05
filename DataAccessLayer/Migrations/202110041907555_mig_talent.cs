namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_talent : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        skillId = c.Int(nullable: false, identity: true),
                        skillName = c.String(maxLength: 50),
                        SkillLevel = c.Byte(nullable: false),
                        TalentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.skillId)
                .ForeignKey("dbo.TalentCards", t => t.TalentId, cascadeDelete: true)
                .Index(t => t.TalentId);
            
            CreateTable(
                "dbo.TalentCards",
                c => new
                    {
                        TalentId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        UserName = c.String(maxLength: 50),
                        TalentAbout = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.TalentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Skills", "TalentId", "dbo.TalentCards");
            DropIndex("dbo.Skills", new[] { "TalentId" });
            DropTable("dbo.TalentCards");
            DropTable("dbo.Skills");
        }
    }
}
