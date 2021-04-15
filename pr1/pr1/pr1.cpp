#include <iostream>
#include <fstream>
#include <string>
using namespace std;

int search(string alph[26], string n)
{
    for (size_t i = 0; i < 26; i++)
    {
        if (alph[i] == n)
        {
            return i;
        }
    }
    return -1;
}

string cryption(string alph[26], string f)
{
    string s, n;
    int j;
    for (size_t i = 0; i < f.length(); i++)
    {
        if (f[i] == ' ')
        {
            s.push_back(' ');
        }
        else
        {
            n.clear();
            n.push_back(f[i]);
            j = search(alph, n);
            if (j < 0)
            {
                cout << "В фразе был встречен необрабатываемый символ. Шифрование не удалось." << endl;
                return f;
            }
            else if ((j > 0) && (j < 19))
            {
                s.append(alph[j + 7]);
            }
            else if ((j > 18) && (j < 21))
            {
                s.append(alph[j - 14]);
            }
            else
            {
                s.append(alph[j - 21]);
            }
        }
    }
    return s;
}

string decryption(string alph[26], string f)
{
    string s, n;
    int j;
    for (size_t i = 0; i < f.length(); i++)
    {
        if (f[i] == ' ')
        {
            s.push_back(' ');
        }
        else
        {
            n.clear();
            n.push_back(f[i]);
            j = search(alph, n);
            if (j < 0)
            {
                cout << "В фразе был встречен необрабатываемый символ. Расшифровка не удалась." << endl;
                return f;
            }
            else if ((j > 0) && (j < 5))
            {
                s.append(alph[j + 21]);
            }
            else if ((j > 4) && (j < 7))
            {
                s.append(alph[j + 14]);
            }
            else
            {
                s.append(alph[j - 7]);
            }
        }
    }
    return s;
}

int main()
{
    setlocale(LC_ALL, "");
    string alph[26] = { "d", "e", "f", "n", "s", "a", "b",
    "c", "g", "h", "i", "j", "k", "l",
    "m", "o", "p", "q", "r", "t", "u",
    "v", "w", "x", "y", "z" };
    string s;
    cout << "Пожалуйста, помните - алфавит шифровки включает в себя только латиницу нижнего регистра" << endl;
    cout << "Выберите режим. Зашифровать - 0, расшифровать - 1" << endl;
    int i;
    cin >> i;
    while ((i != 1) && (i != 0))
    {
        cout << "Выбран неверный режим работы программы." << endl;
        cout << "Выберите режим. Зашифровать - 0, расшифровать - 1" << endl;
        cin >> i;
    }
    ifstream ist;
    ist.open("ist.txt");
    getline(ist, s);
    ofstream ost;
    ost.open("ost.txt");
    if (i == 0)
    {
        cout << "Исходный текст: " << s << endl;
        s = cryption(alph, s);
        cout << "Зашифрованный текст: " << s << endl;
        ost << s;
    }
    else
    {
        cout << "Зашифрованный текст: " << s << endl;
        s = decryption(alph, s);
        cout << "Расшифрованный текст: " << s << endl;
        ost << s;
    }
    return 0;
}