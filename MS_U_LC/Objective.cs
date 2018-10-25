/*

Stworzenie małej aplikacji, która dla zadanych wartości wyliczy stałe, miesięczne raty kredytu.
Parametry wejściowe formularza:
Kwota kredytu, Roczne oprocentowanie, Okres kredytowania w miesiącach.

Wyniki powinny być przedstawione w formie tabeli i zawierać następujące informacje:
Numer miesiąca, wysokość raty (część kapitałowa, część odsetkowa), pozostało do spłaty (kapitał, odsetki)




Wzór na obliczenie raty stałej kredytu:

rata = S * q^n * (q-1)/(q^n-1)

S – kwota zaciągniętego kredytu
n – ilość rat
q – współczynnik równy 1 + (r / m), gdzie
q^n – „q” do potęgi „n”
r – oprocentowanie kredytu
m – ilość rat w okresie dla którego obowiązuje oprocentowanie „r”. Najczęściej oprocentowanie podawanej jest w skali roku, a raty płacone są co miesiąc, więc „m” wtedy jest równe 12.

Przykład:

kwota zaciągniętego kredytu = 100 000 zł
oprocentowanie w skali roku =  3,5%
okres kredytu = 12 lat
ilość rat w roku = 12

q = 1 + (3,50%/12)=1,002916

rata = 100 000 * 1,002916^144 * (1,002916-1)/(1,002916^144 – 1) =
= 100 000 * 1,520886 * 0,002916/0,520886 = 851,41 zł


*/