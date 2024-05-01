Define("First444SetCondition", Or(
        And((PsychSheetPosition(_444) > 10), (PsychSheetPosition(_444) < 38)),
        HasRole("delegate")))
Define("First444Set", Persons(First444SetCondition()))

Define("Second444SetCondition", Or(
        (PsychSheetPosition(_444) < 11),
        (PsychSheetPosition(_444) > 37),
        HasRole("delegate")))
Define("Second444Set", Persons(Second444SetCondition()))

Define("First333SetCondition", Or(
        And((PsychSheetPosition(_333) > 0), (PsychSheetPosition(_333) < 26)),
        HasRole("delegate")))
Define("First333Set", Persons(First333SetCondition()))

Define("Second333SetCondition", Or(
        And((PsychSheetPosition(_333) > 25), (PsychSheetPosition(_333) < 51)),
        HasRole("delegate")))
Define("Second333Set", Persons(Second333SetCondition()))

Define("Third333SetCondition", Or(
        And((PsychSheetPosition(_333) > 50), (PsychSheetPosition(_333) < 76)),
        HasRole("delegate")))
Define("Third333Set", Persons(Third333SetCondition()))
