using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFlowers_Products.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into Products(Name, Price, Description, Stock, ImgURL) " + "Values('Buque de rosas vermelhas', 75.00, 'Rosas vermelhas', 100, 'rosas_vermelhas.jpg')");
            migrationBuilder.Sql("insert into Products(Name, Price, Description, Stock, ImgURL) " + "Values('Buque de rosas brancas', 150.00, 'Rosas brancas', 100, 'rosas_brancas.jpg')");
            migrationBuilder.Sql("insert into Products(Name, Price, Description, Stock, ImgURL) " + "Values('Buque de rosas amarelas', 180.00, 'Rosas amarelas', 100, 'rosas_amarelas.jpg')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from Products");
        }
    }
}
