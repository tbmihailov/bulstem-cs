#bulstem-cs
-----------

A Bulgarian stemmer for .Net

## Algorithm

Implementation of Preslav Nakov BulStem algorithm (http://lml.bas.bg/~nakov/bulstem/index.html)
Port of the Java implementation of Alexander Alexandrov (http://people.ischool.berkeley.edu/~nakov/bulstem/Stemmer.java)

## Stemming levels
Stemmer supports 3 levels of stemming depending on the level of accuracy and errors
LOW(default)
MEDIUM
HIGH

## Usage

```csharp
//default initialization (level Low)
var stemmer = new BulStem.Stemmer();
string stemLevel1 = stemmer.Stem("оставката");
//"остав";

//initialization with level (level Medium)
var stemmer = new BulStem.Stemmer(StemmingLevel.Medium);
string stemLevel2 = stemmer.Stem("оставката");
//"оставк";

//default initialization and later level set (level High)
var stemmer = new BulStem.Stemmer();
stemmer.SetLevel(StemmingLevel.High);
string stemLevel3 = stemmer.Stem("оставката");
//"оставк";

```
