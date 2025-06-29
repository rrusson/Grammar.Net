- Always include curly braces for all control structures, even if they are single-line statements.
- Always leave a CRLF between functions and observe other StyleCop formatting best practices.
- Always provide XML comments for public classes, interfaces, methods, and properties. 
- Start the names of any global private fields in a `class` with an underscore.
- Prefer asynchronous methods and avoid blocking calls like `.Result` or `.Wait()` on tasks.
- Make sure all async method calls include .ConfigureAwait().
- When creating unit tests, use the MS Test framework and MOQ for mocking. Use `Autofac.Extras.Moq` with `AutoMock.GetLoose` for necessary dependency injection when a "fake" or "mock" implementation isn't available.
- Prefer using the `var` keyword for variable declarations when the type is obvious from the right-hand side of the assignment.
- Use `nameof` to refer to method names, property names, and other identifiers instead of hardcoding strings.
- Prefer smaller, single-responsibility methods.
- If a class has a high number of private methods, try to refactor the functionality into new classes.
- Use `IEnumerable<T>` or arrays for method parameters and return types when the collection is not expected to be modified, and `List<T>` only when it is expected to be modified.
- Ensure consistent exception handling practices across the codebase.
