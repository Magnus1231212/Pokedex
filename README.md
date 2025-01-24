# Pokedex Project

## Overview

The Pokedex project is a console application that allows users to manage a collection of Pokemon. Users can log in, view all Pokemon, search for specific Pokemon, and edit the Pokedex.

## Features

- **User Authentication**: Users can log in.
- **View All Pokemon**: Display a list of all Pokemon in the Pokedex.
- **Search Pokemon**: Search for Pokemon by name.
- **Edit Pokedex**: Add, edit, or delete Pokemon entries.

## File Structure

- **CSVManager.cs**: Handles reading and writing to CSV files.
- **User.cs**: Manages user authentication and registration.
- **SubMenus.cs**: Contains methods for various submenu actions.
- **Menu.cs**: Builds and manages the main and submenus.
- **Program.cs**: Entry point of the application, initializes the menu and checks for data files.

## Usage

1. **Login**: Users must log in to access the Pokedex features.
2. **View All Pokemon**: Select the option to see a list of all Pokemon.
3. **Search Pokemon**: Enter the name of the Pokemon to search for.
4. **Edit Pokedex**: Add, edit, or delete Pokemon entries.

## Data Files

- **users.csv**: Stores user information.
- **pokemons.csv**: Stores Pokemon information.

## Requirements

- .NET 9.0 SDK

## Setup

1. Clone the repository.
2. Open the solution in Visual Studio.
3. Build the project.
4. Run the application.
