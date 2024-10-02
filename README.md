# HawkSteel

HawkSteel is a tool for generating accounts and passwords, developed in C# and targeting .NET 8.

## Features

- Generate a specified number of accounts
- Support for custom account prefixes
- Generated accounts and passwords are saved as a CSV file

## Installation

Make sure you have .NET 8 SDK installed. You can download and install it from the [official website](https://dotnet.microsoft.com/download/dotnet/8.0).

## Usage

Run the following command in the terminal to generate accounts:

### Parameters

- `-a, --AccountCount` (required): The number of accounts to generate, with a maximum value of 65535.
- `-p, --AccountPrefix` (optional): Custom account prefix.

### Examples

Generate 100 accounts with the default account prefix:

`./HawkSteel.exe -a 100`


Generate 50 accounts with a custom account prefix `Hawk`:

`./HawkSteel.exe -a 50 -p Hawk`


## Project Structure

- `Program.cs`: Main program file containing argument parsing and account generation logic.

## Contributing

Feel free to submit issues and feature requests. If you are interested in contributing code, please fork this repository and submit a pull request.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
