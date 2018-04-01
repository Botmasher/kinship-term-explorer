# Kinship Term Explorer

This app explores the world's kinship terminology around the world. It uses the traditional categories: "Crow", "Omaha", "Iroquois", "Eskimo", "Sudanese" and "Hawaiian". These buckets are approachable for starters but bring up debates among kinship anthropologists (more on that below).

## Why does this exist?

This is a leadup app for a multimedia project I'm putting together that's focused on the way languages around the world talk about family trees. Cool topic, right? Well, as I slog through the research I'm starting to crave an easy way to view and navigate these various kinship systems. I want to keep their differences straight in my head, and so far the words and diagrams aren't cutting it.

This app helps me by illustrating the way kinship terminology changes around the world. It does this based on some good old standards in kinship anthropology: our world's kinship systems.

## What it is. What it's not.

These systems *do* mean to give illustrative glances at kinship systems. They *do not* mean to be a rigorous or opinionated look at the underlying kinship research.

## Academic basis

The kinship concepts used here are built on the Morgan-Lowie-Murdock tradition of dividing the world's languages and cultures into several kinship systems. Each system is based on standout features, and an archetypal language or region, such as "Sudanese" (for Morgan, highly descriptive) or "Hawaiian" (for Morgan, highly classificatory). These systems are still used for basic breakdowns in research, though with caveats, like in Bennardo's "Space in kinship". In particular, the reasons for slicing up the systems get debated and rejected, such as Morgan's identification of "descriptive" vs "classificatory" systems. Read gives an overview of the drawbacks of this way of classifying kinship terminology in a 2013 paper "A New Approach to Forming a Typology of Kinship Terminology Systems", where the author proposes a more consistent approach.

I originally included "Dravidian" in the list of systems. So far the cross-cousin dynamics of the Dravidian system seem to require wider diagrams. I will discuss Dravidian in the final project, but let's go with the six system model for this leadup project.

## Source Code and Framework

Unlike many of my other leadup projects with their minimal interfaces, this leadup calls for a visual approach where info is geometrically positioned and selectable on screen. I've decided to start developing a scratch app using C# and Unity version `2017.2.0`. The kinship labels are stored per language in a JSON object within `/Assets/Resources/_data`. The game builds a static tree of family members, parses the JSON data, colors and labels family member objects based on data, and updates the members based on user interactions.

The frontend is built in React and located in `/app` and includes the main page, the Unity player and components for selecting kinship systems and example languages. The Unity build is compiled and saved under `/app/public/unity` and loaded at the head of the public `index.html`. React accesses the game session and messages its C# functions through `window.gameInstance` to pass data indicating the current language.
