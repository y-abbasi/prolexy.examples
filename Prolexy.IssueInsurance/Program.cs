// See https://aka.ms/new-console-template for more information

using Figgle;
using Newtonsoft.Json.Linq;
using Prolexy.Client;
using Prolexy.IssueInsurance.Domains.CarBodyInsuranceAgg;
using Prolexy.IssueInsurance.Domains.CustomerAgg;

Console.WriteLine("Powered By:");
Console.WriteLine(
    FiggleFonts.Slant.Render("Prolexy"));
    
var client = ProlexyClientBuilder
    .Default
    .WithToken(
        "MGQzMTdjMGEtODk3MC00MWRmLTkzODgtMzNiNDE4MjU1YWRjOzJkOTEyZWQ0LWQ5ODYtNDk1Ny04ZTYzLTZjZWYzZGMwOTI3Mg==")
    .Build();
var command = new IssueCarBodyInsurance(CarBodyInsuranceId.New, CustomerId.New, true, false, 3, 4250000, 0, 0);
var clientSchema = await client.WithSchemaName<IssueCarBodyInsurance>("CarBodyInsurance");
command = await clientSchema.ExecuteAllRules(command);

ICarBodyInsurance insurance = new CarBodyInsurance(command.Id);

var domainEvents = insurance.Execute(command);
//todo: publish domain events to sync other BC
Console.WriteLine($"added price for additional coverage is: '{insurance.State!.AdditionalCoverage}'");
Console.WriteLine($"discount percentage calculated for this insurance is: '{insurance.State!.DiscountPercentage}'");