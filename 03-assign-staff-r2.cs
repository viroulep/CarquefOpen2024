#include "lib/helpers.cs"
#include "lib/r2-helpers.cs"

Define("SubsequentStaffScorers",
       [
         JobCountScorer(-1),
         ConsecutiveJobScorer(90, -3, 0),
         # for such a small competition just allow any trustable scrambler
         ScrambleSpeedScorer({1, Event}, 10:00s, 5),
         # Convoluted way of checking for newcomers
         GroupScorer(Not((Type(WcaId()) == "String")), -50)
       ])

AssignStaff(
    _555-r2,
    true,
    Persons(Or((PsychSheetPosition(_555) > 15), And(HasRole("delegate"), Not(CompetingIn(_555))))),
    DefaultJobs(2, 2, 1, 12, CanScrambleEvent(_555)),
    DefaultStaffScorers(_555))


AssignStaff(
    _pyram-r2,
    true,
    Persons(Or((PsychSheetPosition(_pyram) > 24), And(HasRole("delegate"), Not(CompetingIn(_pyram))))),
    DefaultJobs(1, 2, 2, 16, CanScrambleEventRelaxed(_pyram)),
    DefaultStaffScorers(_pyram))

AssignStaff(
    _333oh-r2,
    true,
    Persons(Or((PsychSheetPosition(_333oh) > 20), And(HasRole("delegate"), Not(CompetingIn(_333oh))))),
    DefaultJobs(2, 2, 2, 14, CanScrambleEventRelaxed(_333oh)),
    DefaultStaffScorers(_333oh))

# TODO: implement the ClearAssignments for a given round

AssignStaff(
    _444-r2,
    (GroupNumber() == 1),
    Second444Set(),
    DefaultJobs(2, 2, 2, 12, CanScrambleEvent(_444)),
    SubsequentStaffScorers(_444))

AssignStaff(
    _444-r2,
    (GroupNumber() == 2),
    First444Set(),
    DefaultJobs(2, 2, 2, 12, CanScrambleEvent(_444)),
    SubsequentStaffScorers(_444))

AssignStaff(
    _333-r2,
    (GroupNumber() == 1),
    First333Set(),
    DefaultJobs(2, 2, 2, 14, CanScrambleEventRelaxed(_333)),
    SubsequentStaffScorers(_333))
AssignStaff(
    _333-r2,
    (GroupNumber() == 2),
    Third333Set(),
    DefaultJobs(2, 2, 2, 16, CanScrambleEventRelaxed(_333)),
    SubsequentStaffScorers(_333))
AssignStaff(
    _333-r2,
    (GroupNumber() == 3),
    Second333Set(),
    DefaultJobs(2, 2, 2, 16, CanScrambleEventRelaxed(_333)),
    SubsequentStaffScorers(_333))

AssignStaff(
    _333bf-r2,
    true,
    Persons(
      Or(
        And((PsychSheetPosition(_333) < 70), (If(CompetingIn(_333bf), PsychSheetPosition(_333bf), 99) > 15)),
        HasRole("delegate"))),
    DefaultJobs(2, 2, 2, 14, CanScrambleEventRelaxed(_333)),
    SubsequentStaffScorers(_333))

AssignStaff(
    _222-r2,
    true,
    Persons(Or((PsychSheetPosition(_222) > 24), HasRole("delegate"))),
    DefaultJobs(2, 2, 3, 16, CanScrambleEventRelaxed(_222)),
    SubsequentStaffScorers(_222))

AssignStaff(
    _pyram-r3,
    true,
    Persons(Or((PsychSheetPosition(_pyram) > 14), HasRole("delegate"))),
    DefaultJobs(2, 2, 3, 12, CanScrambleEventRelaxed(_pyram)),
    SubsequentStaffScorers(_pyram))

AssignStaff(
    _444-r3,
    true,
    Persons(Or((PsychSheetPosition(_444) > 14), HasRole("delegate"))),
    DefaultJobs(2, 2, 3, 12, CanScrambleEventRelaxed(_444)),
    SubsequentStaffScorers(_444))

ExportWCIF("post-r2.json")
