# Rules Engine Pattern
The Rules Engine is a behavioral pattern that allows for the management of complex logic. This sample pattern sets up a currency translation framework using the pattern.

## Breakdown
The pattern is broken into two parts (source: S. Ardalis):  
1.  *Rules Engine* - processes a set of rules and applies them to produce a result.
2.  *Rule* - describes a condition and may calculate a value.

The interface [IRulesEngine](https://github.com/johnmaloney/Patterns/blob/18a65d6ccca3f391adff449f3131a8c38a4ca937/Patterns/Rules/Contracts/IRulesEngine.cs#L9) 
is the starting point for defining a Rules Engine process.
Once implemented this object holds the execution pattern of rules. It becomes the central point for processing a set of rules.

The interface [IRule](https://github.com/johnmaloney/Patterns/blob/18a65d6ccca3f391adff449f3131a8c38a4ca937/Patterns/Rules/Contracts/IRule.cs#L10)
allows individual rules to be defined.


## Exchanging a Currency Rules Engine
In our sample case we define a [ExchangeCurrencyRulesEngine](https://github.com/johnmaloney/Patterns/blob/18a65d6ccca3f391adff449f3131a8c38a4ca937/Patterns/Rules/Currency/ExchangeCurrencyRulesEngine.cs#L14)
This class takes a [IRuleContext](https://github.com/johnmaloney/Patterns/blob/18a65d6ccca3f391adff449f3131a8c38a4ca937/Patterns/Rules/Currency/CurrencyContext.cs#L11) 
to store data such as the current currency and the desired exchanged currency.
The [ICurrencyRepository](https://github.com/johnmaloney/Patterns/blob/18a65d6ccca3f391adff449f3131a8c38a4ca937/Patterns/Rules/Currency/ExchangeRateCurrencyRepository.cs#L11) 
becomes the datastore for the currency rates.

In the ExchangeCurrencyRulesEngine we define a list of [IRules]() that will be processed. They are not processed until the Execute method is called on the Rules Engine.

The benefit of defining the Rules as modular pieces is that we can use them individually in other workflows pertaining to currency.
It also allows each rule to define the gates for its use and define the messages that the rule sends out to the engines.

Sources:
[Pluralsight course defining the pattern](https://app.pluralsight.com/course-player?clipId=5b90e88a-c91e-4dc7-b3fb-f07cd76f0cf3)