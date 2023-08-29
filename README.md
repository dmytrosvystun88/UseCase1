# Use case #1

## General information

The application is a wrapper around public API https://restcountries.com/v3.1/all. 

It collects countries data from an endpoint and provides ability to narrow down search results by:
- filtering by country name;
- filtering by population size;
- sorting by country name;
- returning paged result;



## How to run locally

The host machine should have .NET6 SDK installed since application is targeting .NET6 Framework.

Open UseCaseAPI.sln file in Visual Studio and build the solution.
Run the UseCaseAPI project, the default browser should be started automatically and should be directed to swagger/index.html page.

## Usage

To make a request provide parameters such as name, population, sortDirection or numberOfResults for \Counties endpoint and hit "Execute" button.
