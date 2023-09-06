# Use case #1 (https://github.com/dmytrosvystun88/UseCase1/actions/workflows/build.yml/badge.svg)

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

To make a request using swagger provide parameters such as name, population, sortDirection or numberOfResults for /Countries endpoint and hit "Execute" button.

To call the endpoint programmatically send the GET request: 'https://localhost:{port}/Countries?name={name}&population={population}&sortDirection={ascend|descend}&numberOfResults={number}'

### Filtering by country name
Filtering by country name is performed by name/common field:

![image](https://github.com/dmytrosvystun88/UseCase1/assets/4784289/1cf83462-4afa-4516-bec6-dd4603588061)

1. The response will contain the result list of country names that contain search parameter (e.g. providing `st` as attribute will find `Estonia`, providing `Sp` will find `Spain`)
   'https://localhost:{port}/Countries?name=st'
2. Search is case insensitive (e.g., providing `sT` will find `Estonia`)
   'https://localhost:{port}/Countries?name=sT' 

### Filtering by population
The filter will search for countries where the population is less than provided number in the millions of people (e.g., by providing value `10`, it will find countries with a population less than '10m')
'https://localhost:{port}/Countries?population=10'

### Sorting
Sorting is also performed by name/common field.
The accepted sort parameter values: 'ascend' or 'descend' (e.g. providing attribute ascend all countries will be sorted from A to Z):
'https://localhost:{port}/Countries?sortDirection={ascend|descend}'

### Pagination
The pagination functionality accepts a number and retrieves first n records (e.g., providing number `15` will return 15 first records from API). 
'https://localhost:{port}/Countries?numberOfResults=15'

### Combining everything together
Let's review the example: 
'https://localhost:{port}/Countries?name=ca&population=10&sortDirection=descend&numberOfResults=15'
The application will look for countries which name contains "ca" in name/common field, population should be less than 10 millions of people. It will sort the results in descending order by name/common and will take '15' records from the beginning.





