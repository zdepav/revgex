## Language description

Language is similar to regular expressions:

Character(s) | Meaning
------------ | -------
non-reserved character (or reserved character preceded by a backslash) | the character is written to the output
[characters] | a random character between the square brackets is chosen, intervals can also be used (e.g. A-Z)
\d, \s, \w, \D, \S, \W | character categories (can also be used inside [])<br/>\d - digit<br/>\s - whitespace<br/>\w - letters, digits and underscore<br/>uppercase letter stands for opposite category (e.g. \D - everything except digits)
(expression) | group, can start with expression like :name; - e.g. (:name;expression) - this creates a group named "name"
\| | '\|' character separates options, when a group (or entire expression) contains multiple options a random one is chosen
. | random ASCII character
\01 | backreference to group 1
\:name; | backreference to group with given name
$01 | backreference to group 1<br/>outputs previously generated text instead of generating new text
$:name; | backreference to group with given name<br/>outputs previously generated text instead of generating new text

*Note: recursion using backreferences is not allowed*

Like in regular expressions, quantifiers can be used:

Quantifier | Meaning
---------- | -------
? | single or no occurence
\* | random repetition count, upper limit is set using the API
\*? | like *, but tends to generate less repetitions
\+ | like *, but always generates at least once
\+? | like +, but tends to generate less repetitions
\{n} | exactly n repetitions
\{n,} | at least n repetitions
\{n,m} | at least n, at most m repetitions

The following pre-defined groups can be used:

Group | Meaning
----- | -------
\::maleName; | male first name
\::femaleName; | female first name
\::surname; | surname
\::byte; | byte (number between 0 and 255)
\::int; | integer (signed 4-byte number)
\::uint; | unsigned integer (unsigned 4-byte number)
\::usPhone; | phone number in US format
\::mailSuffix; | valid email address suffix (part beginning with @, e.g. @gmail.com)
\::passwd; | 8 to 15 characters, contains at least one lowecase letter, one uppercase letter, one digit and one special character

Additional syntax:

Character(s) | Meaning
------------ | -------
(!U expression) | modifying group, modifies its content based on the character after the exclamation mark<br/><br/>'U' - convert letters to uppercase<br/>'l' - (lowercase L) convert letters to lowercase<br/>'C' - capitalizes words<br/>'_' - replaces spaces and dashes by underscores<br/>' ' - replaces dashes and underscores by spaces<br/>'-' - replaces spaces and underscores by dashes<br/>'n' - removes spaces<br/>'t' - trims whitespace from start and end of the text<br/>'0' - removes zeros at beginning of the text<br/>'!' - hides its output, this can be used for comments or to define groups that will be used later
(?: expression ) | group, that can't be referenced
("separator;quantifier expression) | generates multiple texts (based on the quantifier) and separates them with the separator, e.g. (",\ ;{5} \d{2} )
('separator;quantifier expression) | like previous case, but only generates one text and repeats that

<br/>

<br/>

## Library API
The API consists of the **Revgex** class located in **ReverseRegex** namespace. Generator can be created using the following constructor:

```csharp
Revgex(
    string code,
    bool ignoreLineEndings = false,
    bool ignoreWhitespace = false,
    bool allowPredefinedGroups = true
)
```

Argument | Meaning
-------- | -------
code | generator code
ignoreLineEndings | when true, line ending characters are ignored
ignoreWhitespace | when true, whitespace characters are ignored
allowPredefinedGroups | predefined groups can be disabled by setting this to false

- when ignoreWhitespace is set to true, so must be ignoreLineEndings, otherwise ArgumentException will be thrown
- when ignoreWhitespace is set to true, whitespace output can be forced by escaping the characters using a backslash
- if the code contains syntactic errors, FormatException will be thrown with a corresponding error message

Text is generated using the following method:

```csharp
string Generate(int repetitionLimit, Random random = null)
```

Argument | Meaning
-------- | -------
repetitionLimit | upper repetition limit for \* and + quantifiers, has to be at least 1
random | random number generator, when null a default one will be used

- if repetitionLimit < 1 ArgumentOutOfRangeException will be thrown

