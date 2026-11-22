using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CBTech.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CorrigirRelacionamentoClienteEndereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.table_constraints
                        WHERE constraint_name = 'FK_Clientes_Enderecos_Id'
                        AND table_name = 'Clientes'
                    ) THEN
                        ALTER TABLE ""Clientes"" DROP CONSTRAINT ""FK_Clientes_Enderecos_Id"";
                    END IF;
                END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.table_constraints
                        WHERE constraint_name = 'FK_Clientes_Enderecos_EnderecoId'
                        AND table_name = 'Clientes'
                    ) THEN
                        ALTER TABLE ""Clientes"" DROP CONSTRAINT ""FK_Clientes_Enderecos_EnderecoId"";
                    END IF;
                END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF EXISTS (
                        SELECT 1 FROM information_schema.columns
                        WHERE column_name = 'EnderecoId'
                        AND table_name = 'Clientes'
                    ) THEN
                        ALTER TABLE ""Clientes"" DROP COLUMN ""EnderecoId"";
                    END IF;
                END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM pg_indexes
                        WHERE indexname = 'IX_Enderecos_ClienteId'
                        AND tablename = 'Enderecos'
                    ) THEN
                        CREATE UNIQUE INDEX ""IX_Enderecos_ClienteId"" ON ""Enderecos"" (""ClienteId"");
                    END IF;
                END $$;
            ");

            migrationBuilder.Sql(@"
                DO $$
                BEGIN
                    IF NOT EXISTS (
                        SELECT 1 FROM information_schema.table_constraints
                        WHERE constraint_name = 'FK_Enderecos_Clientes_ClienteId'
                        AND table_name = 'Enderecos'
                    ) THEN
                        ALTER TABLE ""Enderecos"" ADD CONSTRAINT ""FK_Enderecos_Clientes_ClienteId""
                            FOREIGN KEY (""ClienteId"") REFERENCES ""Clientes"" (""Id"")
                            ON DELETE CASCADE;
                    END IF;
                END $$;
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Clientes_ClienteId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_ClienteId",
                table: "Enderecos");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_Id",
                table: "Clientes",
                column: "Id",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
