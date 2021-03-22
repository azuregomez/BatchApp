# BatchApp
<h2>Business case<h2>
Sample .net core application to be used with Azure Batch to test different file processing scenarios including files placed in Azure Files Shares.
<ol>
<li>Reads from appsettings.json configuration
<li>Reads and proceses a file given a path
<li>Saves a result to a database.
</ol>
<br/>
<h2>Pre-requisites:<h2>
An available database and teble with fields that map to BatchRun.cs:  identity Id, FName, Result, NodeName, TimeSaved.

