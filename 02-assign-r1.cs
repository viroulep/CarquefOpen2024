#include "lib/helpers.cs"

Define(
  "TopCompetitors",
  [AssignmentSet("top",
      (PsychSheetPosition({1, Event}) <= {2, Number}), (GroupNumber() == {3, Number}))])

Define("FirstRoundsAssignments", [
  Tuple(_555-r1, MakeArray<AssignmentSet>()),
  Tuple(_444bf-r1, MakeArray<AssignmentSet>()),
  Tuple(_pyram-r1, KilianSet(1)),
  Tuple(_333bf-r1, MakeArray<AssignmentSet>()),
  Tuple(_clock-r1, MakeArray<AssignmentSet>()),
  Tuple(_333oh-r1, MakeArray<AssignmentSet>()),
  Tuple(_444-r1, MakeArray<AssignmentSet>()),
  Tuple(_minx-r1, MakeArray<AssignmentSet>()),
  Tuple(_222-r1, MakeArray<AssignmentSet>()),
  Tuple(_333-r1, KilianSet(1))
])


Map(FirstRoundsAssignments(),
    AssignGroups(First<Round, Array<AssignmentSet>>(),
      Concat(
        DelegatesSets(),
        Second<Round, Array<AssignmentSet>>(),
        EarlyAssignmentSets(),
        TopCompetitors(EventForRound(First<Round, Array<AssignmentSet>>()), 10, Length(Groups(First<Round, Array<AssignmentSet>>()))),
        ScramblersSets(),
        EveryoneAssignmentSet()
        ))
   )

Define("DefaultJobs",
       [
         Job("Delegate", {1, Number}, eligibility=HasRole("delegate")),
         Job("scrambler", {2, Number}, eligibility=And({5, Boolean(Person)}, EligibleToStaff())),
         Job("runner", {3, Number}, eligibility=EligibleToStaff()),
         Job("judge", {4, Number}, eligibility=EligibleToStaff())
       ])

Define("DefaultStaffScorers",
       [
         JobCountScorer(-1),
         SameJobScorer(60, -5, 4),
         ConsecutiveJobScorer(90, -3, 0),
         # for such a small competition just allow any trustable scrambler
         ScrambleSpeedScorer({1, Event}, 10:00s, 5),
         # Convoluted way of checking for newcomers
         GroupScorer(Not((Type(WcaId()) == "String")), -50),
         FollowingGroupScorer(-50)
       ])

# Delegates, Scramblers, Runners, Judges, CanScramble?
Define("JobsPerRound", [
  # For 5x5 there are not enough people in groups to properly staff all stations
  Tuple(_555-r1, DefaultJobs(2, 3, 2, 11, CanScrambleEvent(_555))),
  Tuple(_pyram-r1, DefaultJobs(2, 2, 3, 16, CanScrambleEvent(_pyram))),
  Tuple(_333bf-r1, DefaultJobs(2, 2, 1, 8, CanScrambleEvent(_333bf))),
  Tuple(_clock-r1, DefaultJobs(2, 2, 1, 8, CanScrambleEvent(_clock))),
  Tuple(_333oh-r1, DefaultJobs(2, 2, 2, 14, CanScrambleEvent(_333oh))),
  Tuple(_444-r1, DefaultJobs(2, 2, 2, 12, CanScrambleEvent(_444))),
  Tuple(_minx-r1, DefaultJobs(2, 2, 2, 10, CanScrambleEvent(_minx))),
  Tuple(_222-r1, DefaultJobs(2, 2, 3, 16, CanScrambleEvent(_222))),
  Tuple(_333-r1, DefaultJobs(2, 3, 2, 16, CanScrambleEvent(_333)))
])

Map(JobsPerRound(),
  AssignStaff(
    First<Round, Array<AssignmentJob>>(),
    true,
    CompetitorsAndDelegates(EventForRound(First<Round, Array<AssignmentJob>>())),
    #Persons(CompetingIn(EventForRound(First<Round, Array<AssignmentJob>>()))),
    Second<Round, Array<AssignmentJob>>(),
    DefaultStaffScorers(EventForRound(First<Round, Array<AssignmentJob>>()))))

# 444bf is small/specific enough that I extracted it from the map above; specifically
# I want to assign 5x5 scramblers who have competed right before the event.
AssignStaff(
    _444bf-r1,
    true,
    # This is not a typo
    CompetitorsAndDelegates(_555),
    DefaultJobs(2, 2, 2, 12, CanScrambleEvent(_555)),
    DefaultStaffScorers(_555))

# Subsequent rounds:
# saturday: _555-r2, _pyram-r2, _333oh-r2
# sunday: _444-r2, _333-r2, _333bf-r2, _222-r2, _pyram-r3, _444-r3, _333-r3

ExportWCIF("post-assign-first.json")
