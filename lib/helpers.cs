
# Spreadsheet is public here:
# https://docs.google.com/spreadsheets/d/1iA5fnm6euEk5bhhDHcEFa2amVbAyA95zIJDYJrBsEmU/edit?usp=sharing

#ReadSpreadsheet("1iA5fnm6euEk5bhhDHcEFa2amVbAyA95zIJDYJrBsEmU")

# Google is unstable enough that I need to do this
# uncomment later
Define("Scramblers", [2018NEVE02, 2021MUSS01, 2019GASN01, 2021AUBA01, 2023CHAU12, 2008PIAU01, 2021HEBE01, 2023LEPR01, 2022PRUV01, 2017SAFO01, 2019MAIG01, 2022FERR16, 2022DARM01, 2018AUBR01, 2016BRAU02, 2023CHAR07, 2023BERN07, 2008ERBI01, 2008MORE02, 2018TILL02, 2021DAMM01, 2017ROUX01, 2014SEBA01, 2008HANK01, 2022MERL02, 2024BEHI01, 2019CORA01, 2022DUFO01, 2022CHAU04, 2022ROYM01, 2008CHOT01, 2019LEFE02, 2009BONN01, 2008VIRO01, 2016DURE02, 2017RIVA09, 2020ROUY01, 2022HATI01, 2010WEYE02, 2022HAME01, 2016PYWI01])
SetProperty(Scramblers(), "scrambles", 1)

SetProperty(Persons(true), "can-scramble", (NumberProperty("scrambles") == 1))

SetProperty([2009BONN01, 2017PRES04], "scoretaking", true)

# Permitted Scramblers
Define("CanScrambleEvent",
       And(
         In({1, Event}, RegisteredEvents()),
         BooleanProperty("can-scramble"),
         (PsychSheetPosition({1, Event}) < 20)
       ))
Define("CanScrambleEventRelaxed",
       And(
         In({1, Event}, RegisteredEvents()),
         BooleanProperty("can-scramble")
       ))

# AssignmentSet for Kilian, he has organizational errands to run.
# Pyram 1, 333 1, 444 2
Define("KilianSet",
    [AssignmentSet("kilian",
      (WcaId() == "2016FARR02"),
      (GroupNumber() == {1, Number}))])

# Generic AssignmentSet for delegates; spread them evenly accross groups
Define(
  "DelegatesSets",
  [AssignmentSet("delegates",
                 HasRole("delegate"), true)])

# Generic AssignmentSet for score takers, they should compete early.
Define(
  "EarlyAssignmentSets",
  [AssignmentSet("scoretaking",
                 BooleanProperty("scoretaking"),
                 (GroupNumber() == 1))])

# Generic AssignmentSet for everyone
Define("EveryoneAssignmentSet", [AssignmentSet("everyone", true, true)])

# Generic AssignmentSet for scramblers, to spread them evenly
Define(
  "ScramblersSets",
  [AssignmentSet("scramblers",
    CanScrambleEvent(EventForRound(First<Round, Array<AssignmentSet>>())), true)])

# Exclude orga and delegates from regular staffing assignments
Define("EligibleToStaff", And(Not(HasRole("delegate")), Not(HasRole("organizer"))))

# I'm not sure if order is guaranteed to be stable everytime, sort Persons just in case.
Define("CompetitorsAndDelegates", Sort(Persons(Or(CompetingIn({1, Event}), HasRole("delegate"))), Name()))

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
