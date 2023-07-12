using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PDS.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "media",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_media", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "agricultural_producer",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    passwordsalt = table.Column<string>(name: "password_salt", type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    imageurl = table.Column<string>(name: "image_url", type: "text", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    mediaid = table.Column<long>(name: "media_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agricultural_producer", x => x.id);
                    table.ForeignKey(
                        name: "FK_agricultural_producer_media_media_id",
                        column: x => x.mediaid,
                        principalTable: "media",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    passwordsalt = table.Column<string>(name: "password_salt", type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    imageurl = table.Column<string>(name: "image_url", type: "text", nullable: false),
                    role = table.Column<int>(type: "integer", nullable: false),
                    mediaid = table.Column<long>(name: "media_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.id);
                    table.ForeignKey(
                        name: "FK_client_media_media_id",
                        column: x => x.mediaid,
                        principalTable: "media",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    imageurl = table.Column<string>(name: "image_url", type: "text", nullable: false),
                    mediaid = table.Column<long>(name: "media_id", type: "bigint", nullable: false),
                    agriculturalproducerid = table.Column<long>(name: "agricultural_producer_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_agricultural_producer_agricultural_producer_id",
                        column: x => x.agriculturalproducerid,
                        principalTable: "agricultural_producer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_media_media_id",
                        column: x => x.mediaid,
                        principalTable: "media",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "route",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    deliverydate = table.Column<DateTime>(name: "delivery_date", type: "timestamp without time zone", nullable: false),
                    agriculturalproducerid = table.Column<long>(name: "agricultural_producer_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_route", x => x.id);
                    table.ForeignKey(
                        name: "FK_route_agricultural_producer_agricultural_producer_id",
                        column: x => x.agriculturalproducerid,
                        principalTable: "agricultural_producer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    streetname = table.Column<string>(name: "street_name", type: "text", nullable: false),
                    number = table.Column<int>(type: "integer", nullable: false),
                    neighborhood = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    cep = table.Column<string>(type: "text", nullable: false),
                    uf = table.Column<string>(type: "text", nullable: false),
                    completion = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
                    clientid = table.Column<long>(name: "client_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                    table.ForeignKey(
                        name: "FK_address_client_client_id",
                        column: x => x.clientid,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_splitted",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    clientid = table.Column<long>(name: "client_id", type: "bigint", nullable: false),
                    agriculturalproducerid = table.Column<long>(name: "agricultural_producer_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_splitted", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_splitted_agricultural_producer_agricultural_producer_~",
                        column: x => x.agriculturalproducerid,
                        principalTable: "agricultural_producer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_splitted_client_client_id",
                        column: x => x.clientid,
                        principalTable: "client",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_route",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    productid = table.Column<long>(name: "product_id", type: "bigint", nullable: false),
                    routeid = table.Column<long>(name: "route_id", type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_route", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_route_product_product_id",
                        column: x => x.productid,
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_route_route_route_id",
                        column: x => x.routeid,
                        principalTable: "route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    price = table.Column<double>(type: "double precision", nullable: false),
                    productrouteid = table.Column<long>(name: "product_route_id", type: "bigint", nullable: false),
                    ordersplittedid = table.Column<long>(name: "order_splitted_id", type: "bigint", nullable: false),
                    timetoanswer = table.Column<DateTime>(name: "time_to_answer", type: "timestamp with time zone", nullable: false),
                    response = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_order_splitted_order_splitted_id",
                        column: x => x.ordersplittedid,
                        principalTable: "order_splitted",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_product_route_product_route_id",
                        column: x => x.productrouteid,
                        principalTable: "product_route",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_client_id",
                table: "address",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_agricultural_producer_media_id",
                table: "agricultural_producer",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_client_media_id",
                table: "client",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_order_splitted_id",
                table: "order",
                column: "order_splitted_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_route_id",
                table: "order",
                column: "product_route_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_splitted_agricultural_producer_id",
                table: "order_splitted",
                column: "agricultural_producer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_splitted_client_id",
                table: "order_splitted",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_agricultural_producer_id",
                table: "product",
                column: "agricultural_producer_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_media_id",
                table: "product",
                column: "media_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_route_product_id",
                table: "product_route",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_route_route_id",
                table: "product_route",
                column: "route_id");

            migrationBuilder.CreateIndex(
                name: "IX_route_agricultural_producer_id",
                table: "route",
                column: "agricultural_producer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "order_splitted");

            migrationBuilder.DropTable(
                name: "product_route");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "route");

            migrationBuilder.DropTable(
                name: "agricultural_producer");

            migrationBuilder.DropTable(
                name: "media");
        }
    }
}
