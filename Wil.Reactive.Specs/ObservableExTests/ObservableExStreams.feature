@dynamicBindings
Feature: ObservableExStreams
    In order to easily work with streams
    As a user
    I want to be able to expose stream data as an observable stream

Scenario: Read a stream as an obserable stream of byte lists
   Given a stream with contents
     """
     line 1
     """
    When the ToObservableByteBuffer method is called
    Then the result should be ilist of bytes 108, 105, 110, 101, 32, 49

Scenario: Read a null stream as an obserable stream of byte lists
   Given _a null stream
    When the ToObservableByteBuffer method is called
    Then an exception should have been thrown
