# Hackathon Game Template
Template that can be used to quickly setup a Unity game which includes Zenject as a Dependency Injection Framework.
The template includes the following:

- A "Splash Screen", "Game" and "Game Over" scene.
- A state machine which uses injected game states to control the flow between these scenes.
- Zenject plugin 9.1.0 (https://github.com/svermeulen/Extenject) for Dependency Injection.
- UniRx and UniRx.Async plugin for async / await and tasks.
- Logging system that can be used to categorize different logging types, and color them automatically on the console.
- Injected Camera system that can be reused accross scenes.
