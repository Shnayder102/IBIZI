import random

from math import gcd
from math import sqrt

from sympy import isprime


def generate_key_pair(p, q):
    if not (isprime(p) and isprime(q)):
        raise ValueError('Числа должны быть простыми!')
    elif p == q:
        raise ValueError('Числа не должны быть одинаковыми!')
    n = p * q

    d = (p-1) * (q-1)

    e = random.randrange(1, d)

    g = gcd(e, d)
    while g != 1:
        e = random.randrange(1, d)
        g = gcd(e, d)

    s = multiplicative_inverse(e, d)

    return ((e, n), (s, n))

def multiplicative_inverse(e, d):
    k = 0
    x1 = 0
    x2 = 1
    y1 = 1
    temp_phi = d

    while e > 0:
        temp1 = temp_phi // e
        temp2 = temp_phi - temp1 * e
        temp_phi = e
        e = temp2

        x = x2 - temp1 * x1
        y = k - temp1 * y1

        x2 = x1
        x1 = x
        k = y1
        y1 = y

    if temp_phi == 1:
        return k + d

def encrypt(pk, plaintext):
    key, n = pk
    cipher = [pow(ord(char), key, n) for char in plaintext]
    return cipher


def decrypt(pk, ciphertext):
    key, n = pk
    dba = [str(pow(char, key, n)) for char in ciphertext]
    plain = [chr(int(char2)) for char2 in dba]
    return ''.join(plain)

if __name__ == "__main__":

    print("RSA crypt: ")

    p = int(random.randrange(1, 99999999999999999999999999999999999999999999))
    q = int(random.randrange(10000000000000000000000000000000000000000000//p, 99999999999999999999999999999999999999999999//p))

    while not isprime(p):
        p = int(random.randrange(1, 99999999999999999999999999999999999999999999))
    while not isprime(q):
        q = int(random.randrange(10000000000000000000000000000000000000000000//p, 99999999999999999999999999999999999999999999//p))

    public, private = generate_key_pair(p, q)

    print("Public key: ", public)
    print("Private key: ", private)

    message = input("Введите сообщение: ")
    encrypted_msg = encrypt(public, message)

    print("Зашифрованное сообщение: ", ''.join(map(lambda x: str(x) + " ", encrypted_msg)))
    print("Расшифрованное сообщение: ", decrypt(private, encrypted_msg))
