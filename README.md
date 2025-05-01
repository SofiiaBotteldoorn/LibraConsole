LibraConsole – Bibliotheekbeheer in C# (.NET Console App)
Uitgebreide console-applicatie geschreven in C#, ontworpen om bibliotheekbeheer te simuleren en diverse concepten uit objectgeoriënteerd programmeren (OOP) en moderne C#-technieken te demonstreren

Functionaliteiten:

-  Boekbeheer met verschillende types media (boeken, e-boeken, tijdschriften, audioboeken)
-  Leden- en auteursbeheer
-  Interface- en inheritance polymorfisme
-  Simulatie van uitleen- en inleverlogica (inclusief boeteberekening)
-  Custom exception handling voor ongeldige invoer
-  Pattern matching en typechecking


   Gebruikte C# Concepten

Concept                      Toegepast in

Abstracte klassen     -   MediaItem, Persoon

Interfaces            -   IIdentificeerbaar, IMediaItem

Polymorfisme          -   Boek : MediaItem, Lezer : Persoon, enz.

Events en delegates   -   MediaUitgeleend, MediaIngeleverd

LINQ                  -   Sorteren van auteurs en leden

Pattern matching      -   switch op MediaItem types

Custom exceptions     -   VoornaamException, GeboortedatumException, enz.

Static properties     -   Bibliotheek.BoetePerDag

Validatie & encapsulatie - ISBN-check, prijscontrole, init-only properties
