<p><a target="_blank" href="https://app.eraser.io/workspace/tSK77B9wLVWY3YpbhYEL" id="edit-in-eraser-github-link"><img alt="Edit in Eraser" src="https://firebasestorage.googleapis.com/v0/b/second-petal-295822.appspot.com/o/images%2Fgithub%2FOpen%20in%20Eraser.svg?alt=media&amp;token=968381c8-a7e7-472a-8ed6-4a6626da5501"></a></p>

# AWS Lambda Simple SQS Function Project
This starter project consists of:

- Function.cs - class file containing a class with a single function handler method
- aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS
You may also have a test project depending on the options selected.

The generated function handler responds to events on an Amazon SQS queue.

After deploying your function you must configure an Amazon SQS queue as an event source to trigger your Lambda function.

## Here are some steps to follow from Visual Studio:
To deploy your function to AWS Lambda, right click the project in Solution Explorer and select _Publish to AWS Lambda_.

To view your deployed function open its Function View window by double-clicking the function name shown beneath the AWS Lambda node in the AWS Explorer tree.

To perform testing against your deployed function use the Test Invoke tab in the opened Function View window.

To configure event sources for your deployed function use the Event Sources tab in the opened Function View window.

To update the runtime configuration of your deployed function use the Configuration tab in the opened Function View window.

To view execution logs of invocations of your function use the Logs tab in the opened Function View window.

## Here are some steps to follow to get started from the command line:
Once you have edited your template and code you can deploy your application using the [﻿Amazon.Lambda.Tools Global Tool](https://github.com/aws/aws-extensions-for-dotnet-cli#aws-lambda-amazonlambdatools) from the command line.

Install Amazon.Lambda.Tools Global Tools if not already installed.

```
dotnet tool install -g Amazon.Lambda.Tools
```
If already installed check if new version is available.

```
dotnet tool update -g Amazon.Lambda.Tools
```
Execute unit tests

```
cd "CommuniQueueV2.EventProcessor/test/CommuniQueueV2.EventProcessor.Tests"
dotnet test
```
Deploy function to AWS Lambda

```
cd "CommuniQueueV2.EventProcessor/src/CommuniQueueV2.EventProcessor"
dotnet lambda deploy-function
```




<!--- Eraser file: https://app.eraser.io/workspace/tSK77B9wLVWY3YpbhYEL --->