#include "lib/scramble-eligibility.cs"


Define("NobodyAssignmentSet", [AssignmentSet("nobody", false, false)])
Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

# AssignmentSet for Kilian, he has organizational errands to run.
# Pyram 1, 333 1, 444 2
Define("KilianSet",
  [AssignmentSet("kilian",
                 (WcaId() == "2016FARR02"),
                 (GroupNumber() == {1, Number}))])

# Scramblers balancing set

# Workaround the fact we can't seem to nest user-defined function calls
# And(In({1, Event}, RegisteredEvents()), BooleanProperty("can-scramble"))
Define("ScramblersSet",
       [AssignmentSet("scramblers", And(In({1, Event}, RegisteredEvents()), BooleanProperty("can-scramble")), true)])

# These people should compete early.
Define(
  "EarlyAssignmentSets",
  [AssignmentSet("scoretaking",
                 BooleanProperty("scoretaking"),
                 (GroupNumber() == 1))])


Map([
  Tuple(_555-r1, MakeArray<AssignmentSet>()),
  Tuple(_pyram-r1, KilianSet(1))
],
AssignGroups(First<Round, Array<AssignmentSet>>(),
    Concat(
        Second<Round, Array<AssignmentSet>>(),
        EarlyAssignmentSets(),
        [AssignmentSet("scramblers", CanScrambleEvent(EventForRound(First<Round, Array<AssignmentSet>>())), true)],
        EveryoneAssignmentSet()
        ))
        )
