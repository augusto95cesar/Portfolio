namespace pontoid.myclinica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class primeiroBd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                        VagasAtendimentoId = c.Int(nullable: false),
                        PacienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pacientes", t => t.PacienteId, cascadeDelete: true)
                .ForeignKey("dbo.vagasAtendimentoes", t => t.VagasAtendimentoId, cascadeDelete: true)
                .Index(t => t.VagasAtendimentoId)
                .Index(t => t.PacienteId);
            
            CreateTable(
                "dbo.pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePaciente = c.String(),
                        Telefone = c.String(),
                        CPF = c.String(),
                        Email = c.String(),
                        ConvenioId = c.Int(),
                        Matricula = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.vagasAtendimentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataConsulta = c.DateTime(nullable: false),
                        Horas = c.DateTime(nullable: false),
                        DateTimeDisponivel = c.Boolean(nullable: false),
                        ClinicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.clinicas", t => t.ClinicaId, cascadeDelete: true)
                .Index(t => t.ClinicaId);
            
            CreateTable(
                "dbo.clinicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeClinica = c.String(),
                        CNPJ = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.convenios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeConvenio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.vagasAtendimentoes", "ClinicaId", "dbo.clinicas");
            DropForeignKey("dbo.agendamentoes", "VagasAtendimentoId", "dbo.vagasAtendimentoes");
            DropForeignKey("dbo.agendamentoes", "PacienteId", "dbo.pacientes");
            DropIndex("dbo.vagasAtendimentoes", new[] { "ClinicaId" });
            DropIndex("dbo.agendamentoes", new[] { "PacienteId" });
            DropIndex("dbo.agendamentoes", new[] { "VagasAtendimentoId" });
            DropTable("dbo.convenios");
            DropTable("dbo.clinicas");
            DropTable("dbo.vagasAtendimentoes");
            DropTable("dbo.pacientes");
            DropTable("dbo.agendamentoes");
        }
    }
}
