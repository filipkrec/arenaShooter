Arhitektura projekta je top-down, temeljena na Humble MonoBehaviour pristupu (odvajanje MonoBehaviour sloja od ostatka logike gdje god je to bilo moguće).

Primijenjeni su osnovni principi objektno orijentiranog programiranja, uključujući SOLID načela, modularnost i decoupling gdje je primjenjivo, izbjegavanje ponavljanja koda (DRY) te jasno razdvajanje odgovornosti po logičkim domenama i entitetima.

Projekt je koncipiran kao samostojeći, završeni proizvod bez pretpostavke daljnjeg programskog razvoja, s jasno izloženim konfiguracijama (jezik, balans igre, razine, protivnici i slično). Time je omogućeno jednostavno podešavanje i nadogradnja temeljne gameplay strukture.

Kod je otvoren za suradnju, s naglaskom na čitljivost i preglednost, kako bi se po potrebi mogao dalje razvijati te proširivati novim vrstama funkcionalnosti za protivnike, pickupove, levele i ostale entitete igre.

Vizualni sloj je maksimalno odvojen od logičkog, što omogućuje jednostavnu zamjenu asseta po potrebi, od UI elemenata do 3D modela.

Pojedini sustavi (gameplay, input, audio, izbornici, lokalizacija i dr.) implementirani su kao međusobno neovisni moduli, što omogućuje njihov paralelni i neovisan razvoj.

UI je implementiran kao pasivni sustav koji ne utječe na gameplay logiku, već isključivo reflektira promjene u njoj.

Optimizacija je provedena u završnoj fazi razvoja, pri čemu su asseti logički i fizički odvojeni kako bi se izbjeglo nepotrebno učitavanje resursa u scenama u kojima se ne koriste.

Korišteni su isključivo paketi nužni za potrebe projekta.

Dio funkcionalnosti implementiran je i s ciljem demonstracije poznavanja određenih tehnologija i pristupa, s obzirom na to da se radi o zadatku u sklopu natječaja za posao.

Projekt je osnovno testiran, no moguće su pojave bugova koje bi se otkrile tek kroz detaljnije i dugotrajnije testiranje.

UML dijagram izrađen prije početka implementacije priložen je u repozitoriju (drawio datoteka).

Ukupno vrijeme utrošeno na razvoj projekta iznosi približno 21 sat, uz odstupanje od nekoliko sati. Razvoj je bio vremenski rascjepkan zbog blagdanskog razdoblja i drugih obveza, što je također utjecalo na ukupno trajanje rada.

Iako nije bilo strogo nužno, dodatno vrijeme uloženo je u izradu barem osnovno koherentnih i vizualno prihvatljivih asseta i dizajna, kako projekt ne bi bio isključivo tehnička demonstracija s generičkim primitivima.

Za buildanje projekta potrebna je verzija Unityja 2022.3.21f (navedena u zadatku), uz korištenje Unityjevog standardnog build pipelinea za Windows platformu.

Cijeli projekt dostupan je u priloženom repozitoriju.