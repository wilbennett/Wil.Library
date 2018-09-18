@dynamicBindings
Feature: ReactiveFileUtils
    In order to easily work with files
    As a user
    I want to be able to expose file contents as an observable stream

Background:
    Given a name of a temporary file
      And the file contents is set to
      """
      line 1
      line 2
      """

Scenario: Read a file as an stream of chars
    When the ReadObservableChars method is called with the filename
    Then the result should be ilist of chars "l", "i", "n", "e", " ", "1", "\r", "\n", "l", "i", "n", "e", " ", "2"

Scenario: Read a file as an stream of strings
    When the ReadObservableStrings method is called with the filename
    Then the result should be ilist of strings "line 1", "line 2"

Scenario: Read a file as an stream of bytes
    When the ReadObservableBytes method is called with the filename
    Then the result should be ilist of bytes 108, 105, 110, 101, 32, 49, 13, 10, 108, 105, 110, 101, 32, 50

Scenario: Read a file as an stream of byte lists
   Given bufferSize is 8
    When the ReadObservableByteBuffer method is called with the filename and bufferSize
    Then matrix "result" should be byte matrix "[[108, 105, 110, 101, 32, 49, 13, 10] [108, 105, 110, 101, 32, 50]]"

Scenario: Read a non-existent file as an stream of chars
   Given a name of a temporary file
    When the ReadObservableChars method is called with the filename
    Then an exception should have been thrown

Scenario: Read a non-existent file as an stream of strings
   Given a name of a temporary file
    When the ReadObservableStrings method is called with the filename
    Then an exception should have been thrown
