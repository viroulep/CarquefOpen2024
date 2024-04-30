Define("First444SetCondition", Or(
        And((PsychSheetPosition(_444) > 10), (PsychSheetPosition(_444) < 38)),
        HasRole("delegate")))
Define("First444Set", Persons(First444SetCondition()))

Define("Second444SetCondition", Or(
        (PsychSheetPosition(_444) < 11),
        (PsychSheetPosition(_444) > 37),
        HasRole("delegate")))
Define("Second444Set", Persons(Second444SetCondition()))
