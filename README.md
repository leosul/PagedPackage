# PagedPackage
Simple package to return paginated data

![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)

The main objective of this package is to facilitate the return of paginated data, simply implementing the result of its data to the entity of the corresponding package.

## Dependencies

- .NET6 or >
- Microsoft.EntityFrameworkCore

## Installation

[nuget PagedPackage](https://www.nuget.org/packages/PagedPackage/1.0.0)

```sh
Install-Package PagedPackage -Version 1.0.0
```

## How to use

```csharp
public async Task<PagedResult<Customers>> GetCustomersAsync(int pageNumber, int pageSize)
{
    return await PagedResult<Customers>.ToPagedList(_context.Customers, pageNumber, pageSize);
}
```

##The Result Is

![image](https://user-images.githubusercontent.com/22174344/187715915-8a1b2d08-d339-4a87-91b9-f14bd8f17bef.png)

![image](https://user-images.githubusercontent.com/22174344/187715544-5af41530-a900-47c5-93b7-7921a7ceaaa1.png)

As you can see, it will return:

#PageNumber

#PageSize 

#TotalRows 

#TotalPages 

#Items 

#HasNextPage 

#HasPreviousPage 




See the example that is in the project for its implementation.


