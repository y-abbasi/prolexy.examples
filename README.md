# prolexy.examples

Here you will see examples and cases where Prolexy can be used, as well as how to work with Prolexy.Client in cssharp.

## Documentation
Prolex is a rules management system where you can dynamically add, edit or delete rules at runtime. This is the link to Prolexi's [https://www.prolexy.net/docs](documentation).

## How to run

### Registration
To run this example, you need to Signup for free through the [https://www.prolexy.net/admin](account creation) link.
For the first time when you log in, you must enter the company information, later you can assign other users for this company and you can control their access to the rules.

### Define schema
The next step is to create a schema, for example, you need a schema as follows to calculate the total price in addition to additional coverages for car body insurance and also to calculate the discount.

```javascript
class CarInsuranceBody{
    bool TheftCoverage,
    bool NaturalDisasterCoverage,
    number DamageUnUseHistory,
    number BasicPremium,
    number DiscountPercentage,
    number AdditionalCoverage
}
```
### Define rules
After creating the schema, it is time to define the rules that you want to apply to an insurance policy.
A law has two important parts. The first is the conditions for the implementation of the law, and the second part is the operation that must be implemented if the first part is fulfilled.
For example, you can set the conditions of the rule to choose the coverage of natural events. That is, if the customer requests natural disaster coverage for his insurance policy,
you want to add 5 percent to the‌ `BsicPremium` of the insurance policy to cover the risk caused by natural disasters. So, in the action section, the value of 5 should be added to `AdditionalCoverage`.

### Create Access Token

In order to run the rules through your application, you need to create a new client through the Clients menu. After registering the client,
the access token will be displayed to you. Copy it to use it later in your application.

### Install nuget package

Add the proxy client package to your project with the following command.

> dotnet add package Prolexy.Client

### Configure and Build Prolexy client

At this stage, you should configure your client through the `ProlexyClientBuilder` and then instantiate it.
For configuration, the default settings for this project are enough and you can only set the access token

```csharp
var client = ProlexyClientBuilder
    .Default
    .WithToken(
        "Past your Access token here.")
    .Build();
```

### Execute Rules

To execute a rule, you must create an example from the created schema, and then run the rules on it through the client created in the previous step as follows.

```csharp
var command = new IssueCarBodyInsurance
{
    TheftCoverage = true,
    NaturalDisasterCoverage = true,
    DamageUnUseHistory = 3,
    BasicPremium = 43090000,
    DiscountPercentage = 0,
    AdditionalCoverage = 0
};
var clientSchema = await client.WithSchemaName<IssueCarBodyInsurance>("CarBodyInsurance");
command = await clientSchema.ExecuteAllRules(command);
```

دddd
> If you don't want all the rules to be executed on your input, you can execute a rule by using the `ExecuteByName` method.
