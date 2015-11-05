# DNAExercise
A MVC Exercise

Problem:
Below is a list of characters representing a DNA test result that has been corrupted with invalid data. These corrupt test results need to be properly reformatted in order to correctly answer the doctor’s question. The following rules should be applied to the formatting:
- Only ‘A’, ‘C’, ‘T’, and ‘G’ are valid characters. All other characters should be removed.
- All characters in the results should be shown in upper case.
- Results should be broken into four character long sequences, separated by a space between each sequence.

Write the code you would use to reformat the data and answer the doctor’s question. Assume the test results are provided to you in a text file that needs to be read into your application.
“How many times does the sequence ‘CCTG’ occur in the following test result?”
Corrupt Test Result:

> ACAAGaATGCCtATTGTCCCCCGDGCCTCCTGCTGCTGCTGCTRCTCCGGGGCCACGGCCACCGCTGCCCTGCLCCCTcGGAGGGTGGCCCgCACCGGCCfGAGAgCAGCGAGkCATlATGCAGG;AAGlCGGCAGjGRAAA,TAAKcGGA87AHAAGC7AGCCTCCTGACTTTCcCTCGCTTaGGTG6GTTTGAFGTG/GACC0TCCCAGGCCAGTGCCGGGCcCCCT[CATAGGAGAGGAAGCTggCGGGKAGGLTGGCCAGGCGGCd3xtA5GGAAGGWCEGgCQACgCCCC6CCAGCAtA8TCC45tGCGCGCCGGGACAGAATGCCCTGCAGGAACTTCTThCTGGAAGACCTHTCgTCCTCCTGgCAAATAgAAACCFT

Extra Credit:
Provide a user interface where the user can browse and upload the text file. On the interface, include an input text box where the user can enter and search for any four letter combination of A, C, T, or G after the rules outlined above have been applied to the text in the uploaded file. For example, I should be able to search the same text as above for ‘ACGC’ and see the frequency of the sequence as a result.
