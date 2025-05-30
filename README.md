# Repro for coverlet ExcludeByAttribute + Generated Log Methods Issue

Using...

- `coverlet.collector` 6.0.4
- .NET 9.0.203
- `Coverage.runsettings` that include `ExcludeByAttribute`

...if you gather coverage

`dotnet test -c Release --logger:trx --collect:"XPlat Code Coverage" --settings ./Coverage.runsettings`

...then you will see that no coverage is gathered.

This appears to be a conflict between how excluding `GeneratedCodeAttribute` is handled along with how [generated `LoggerMessage` methods work](https://learn.microsoft.com/en-us/dotnet/core/extensions/logger-message-generator).

To get coverage to appear, _either_:

- Modify `Coverage.runsettings` to remove the `ExcludeByAttribute` node; OR
- Comment out the little private generated logger method in the `SimpleMiddleware` class.

This may be due to changes in how .NET 9 generates these methods. This same issue does not happen in .NET 8.
