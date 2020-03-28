# Docker Secret Configuration Provider

## Introduction

This package allows the use of Docker secret as configuration source. The secret file name is used as config key.

File names are case-insensitive. Use double underline `__` in file name for colon.

## Installation

The fastest way to install the package is via [NuGet](https://www.nuget.org/packages/ConfigurationProvider.DockerSecret):

    dotnet add package ConfigurationProvider.DockerSecret

## Usage

Simply call the extension method on the `IHostBuilder`:

    builder.ConfigureAppConfiguration(configure =>
    {
        configure.AddDockerSecret();
    })
