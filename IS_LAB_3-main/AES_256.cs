using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_LAB3
{
    class AES_256
    {
        static int nb = 4;  // число столбцов State (в AES = 4)
        static int nr = 14; // количество раундов (если nb = 4, то nr = 14)
        static int nk = 8;  // длина ключа в 32-битных словах

        static Dictionary<char, int> hex_symbols_to_int = new Dictionary<char, int> {
            {'a', 10},
            {'b', 11},
            {'c', 12},
            {'d', 13},
            {'e', 14},
            {'f', 15}
        };

        static List<byte> sbox = new List<byte>() {
            0x63, 0x7c, 0x77, 0x7b, 0xf2, 0x6b, 0x6f, 0xc5, 0x30, 0x01, 0x67, 0x2b, 0xfe, 0xd7, 0xab, 0x76,
            0xca, 0x82, 0xc9, 0x7d, 0xfa, 0x59, 0x47, 0xf0, 0xad, 0xd4, 0xa2, 0xaf, 0x9c, 0xa4, 0x72, 0xc0,
            0xb7, 0xfd, 0x93, 0x26, 0x36, 0x3f, 0xf7, 0xcc, 0x34, 0xa5, 0xe5, 0xf1, 0x71, 0xd8, 0x31, 0x15,
            0x04, 0xc7, 0x23, 0xc3, 0x18, 0x96, 0x05, 0x9a, 0x07, 0x12, 0x80, 0xe2, 0xeb, 0x27, 0xb2, 0x75,
            0x09, 0x83, 0x2c, 0x1a, 0x1b, 0x6e, 0x5a, 0xa0, 0x52, 0x3b, 0xd6, 0xb3, 0x29, 0xe3, 0x2f, 0x84,
            0x53, 0xd1, 0x00, 0xed, 0x20, 0xfc, 0xb1, 0x5b, 0x6a, 0xcb, 0xbe, 0x39, 0x4a, 0x4c, 0x58, 0xcf,
            0xd0, 0xef, 0xaa, 0xfb, 0x43, 0x4d, 0x33, 0x85, 0x45, 0xf9, 0x02, 0x7f, 0x50, 0x3c, 0x9f, 0xa8,
            0x51, 0xa3, 0x40, 0x8f, 0x92, 0x9d, 0x38, 0xf5, 0xbc, 0xb6, 0xda, 0x21, 0x10, 0xff, 0xf3, 0xd2,
            0xcd, 0x0c, 0x13, 0xec, 0x5f, 0x97, 0x44, 0x17, 0xc4, 0xa7, 0x7e, 0x3d, 0x64, 0x5d, 0x19, 0x73,
            0x60, 0x81, 0x4f, 0xdc, 0x22, 0x2a, 0x90, 0x88, 0x46, 0xee, 0xb8, 0x14, 0xde, 0x5e, 0x0b, 0xdb,
            0xe0, 0x32, 0x3a, 0x0a, 0x49, 0x06, 0x24, 0x5c, 0xc2, 0xd3, 0xac, 0x62, 0x91, 0x95, 0xe4, 0x79,
            0xe7, 0xc8, 0x37, 0x6d, 0x8d, 0xd5, 0x4e, 0xa9, 0x6c, 0x56, 0xf4, 0xea, 0x65, 0x7a, 0xae, 0x08,
            0xba, 0x78, 0x25, 0x2e, 0x1c, 0xa6, 0xb4, 0xc6, 0xe8, 0xdd, 0x74, 0x1f, 0x4b, 0xbd, 0x8b, 0x8a,
            0x70, 0x3e, 0xb5, 0x66, 0x48, 0x03, 0xf6, 0x0e, 0x61, 0x35, 0x57, 0xb9, 0x86, 0xc1, 0x1d, 0x9e,
            0xe1, 0xf8, 0x98, 0x11, 0x69, 0xd9, 0x8e, 0x94, 0x9b, 0x1e, 0x87, 0xe9, 0xce, 0x55, 0x28, 0xdf,
            0x8c, 0xa1, 0x89, 0x0d, 0xbf, 0xe6, 0x42, 0x68, 0x41, 0x99, 0x2d, 0x0f, 0xb0, 0x54, 0xbb, 0x16
        };

        static List<byte> inv_sbox = new List<byte>() {
            0x52, 0x09, 0x6a, 0xd5, 0x30, 0x36, 0xa5, 0x38, 0xbf, 0x40, 0xa3, 0x9e, 0x81, 0xf3, 0xd7, 0xfb,
            0x7c, 0xe3, 0x39, 0x82, 0x9b, 0x2f, 0xff, 0x87, 0x34, 0x8e, 0x43, 0x44, 0xc4, 0xde, 0xe9, 0xcb,
            0x54, 0x7b, 0x94, 0x32, 0xa6, 0xc2, 0x23, 0x3d, 0xee, 0x4c, 0x95, 0x0b, 0x42, 0xfa, 0xc3, 0x4e,
            0x08, 0x2e, 0xa1, 0x66, 0x28, 0xd9, 0x24, 0xb2, 0x76, 0x5b, 0xa2, 0x49, 0x6d, 0x8b, 0xd1, 0x25,
            0x72, 0xf8, 0xf6, 0x64, 0x86, 0x68, 0x98, 0x16, 0xd4, 0xa4, 0x5c, 0xcc, 0x5d, 0x65, 0xb6, 0x92,
            0x6c, 0x70, 0x48, 0x50, 0xfd, 0xed, 0xb9, 0xda, 0x5e, 0x15, 0x46, 0x57, 0xa7, 0x8d, 0x9d, 0x84,
            0x90, 0xd8, 0xab, 0x00, 0x8c, 0xbc, 0xd3, 0x0a, 0xf7, 0xe4, 0x58, 0x05, 0xb8, 0xb3, 0x45, 0x06,
            0xd0, 0x2c, 0x1e, 0x8f, 0xca, 0x3f, 0x0f, 0x02, 0xc1, 0xaf, 0xbd, 0x03, 0x01, 0x13, 0x8a, 0x6b,
            0x3a, 0x91, 0x11, 0x41, 0x4f, 0x67, 0xdc, 0xea, 0x97, 0xf2, 0xcf, 0xce, 0xf0, 0xb4, 0xe6, 0x73,
            0x96, 0xac, 0x74, 0x22, 0xe7, 0xad, 0x35, 0x85, 0xe2, 0xf9, 0x37, 0xe8, 0x1c, 0x75, 0xdf, 0x6e,
            0x47, 0xf1, 0x1a, 0x71, 0x1d, 0x29, 0xc5, 0x89, 0x6f, 0xb7, 0x62, 0x0e, 0xaa, 0x18, 0xbe, 0x1b,
            0xfc, 0x56, 0x3e, 0x4b, 0xc6, 0xd2, 0x79, 0x20, 0x9a, 0xdb, 0xc0, 0xfe, 0x78, 0xcd, 0x5a, 0xf4,
            0x1f, 0xdd, 0xa8, 0x33, 0x88, 0x07, 0xc7, 0x31, 0xb1, 0x12, 0x10, 0x59, 0x27, 0x80, 0xec, 0x5f,
            0x60, 0x51, 0x7f, 0xa9, 0x19, 0xb5, 0x4a, 0x0d, 0x2d, 0xe5, 0x7a, 0x9f, 0x93, 0xc9, 0x9c, 0xef,
            0xa0, 0xe0, 0x3b, 0x4d, 0xae, 0x2a, 0xf5, 0xb0, 0xc8, 0xeb, 0xbb, 0x3c, 0x83, 0x53, 0x99, 0x61,
            0x17, 0x2b, 0x04, 0x7e, 0xba, 0x77, 0xd6, 0x26, 0xe1, 0x69, 0x14, 0x63, 0x55, 0x21, 0x0c, 0x7d
        };

        static List<List<byte>> rcon = new List<List<byte>>()
        {
            new List<byte> {0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80, 0x1b, 0x36},
            new List<byte> {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},
            new List<byte> {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00},
            new List<byte> {0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00}
        };

        public static List<byte> encrypt(List<byte> input_bytes, string key)
        {
            List<List<byte>> state = new List<List<byte>>();

            for (int i = 0; i < 4; i++)
            {
                state.Add(new List<byte>());
            }

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < nb; c++)
                {
                    state[r].Add(input_bytes[r + 4 * c]);
                }
            }

            List<List<byte>> key_schedule = key_expansion(key);

            state = add_round_key(state, key_schedule);

            for (int rnd = 1; rnd < nr; rnd++)
            {
                state = sub_bytes(state);
                state = shift_rows(state);
                state = mix_columns(state);
                state = add_round_key(state, key_schedule, rnd);
            }

            state = sub_bytes(state);
            state = shift_rows(state);
            state = add_round_key(state, key_schedule, nr);


            List<byte> output = Enumerable.Repeat<byte>(0x00, 4 * nb).ToList();

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < nb; c++)
                {
                    output[r + 4 * c] = state[r][c];
                }
            }

            return output;
        }

        public static List<byte> decrypt(List<byte> cipher, string key)
        {
            List<List<byte>> state = new List<List<byte>>();

            for (int i = 0; i < 4; i++)
            {
                state.Add(new List<byte>());
            }

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < nb; c++)
                {
                    state[r].Add(cipher[r + 4 * c]);
                }
            }

            List<List<byte>> key_schedule = key_expansion(key);

            state = add_round_key(state, key_schedule, nr);

            int rnd = nr - 1;
            while (rnd >= 1)
            {
                state = shift_rows(state, inv: true);
                state = sub_bytes(state, inv: true);
                state = add_round_key(state, key_schedule, rnd);
                state = mix_columns(state, inv: true);

                rnd -= 1;
            }

            state = shift_rows(state, inv: true);
            state = sub_bytes(state, inv: true);
            state = add_round_key(state, key_schedule, rnd);

            List<byte> output = Enumerable.Repeat<byte>(0x00, 4 * nb).ToList();

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < nb; c++)
                {
                    output[r + 4 * c] = state[r][c];
                }
            }

            return output;
        }


        static List<List<byte>> key_expansion(string key)
        {
            List<byte> key_symbols = Encoding.ASCII.GetBytes(key).ToList();

            int key_length = key_symbols.Count();
            if (key_length < 4 * nk)
            {
                for (int i = 0; i < 4 * nk - key_length ; i++)
                {
                    key_symbols.Add(0x01);
                }
            }

            List<List<byte>> key_schedule = new List<List<byte>>() {
                new List<byte>(),
                new List<byte>(),
                new List<byte>(),
                new List<byte>()
            };

            for (int r = 0; r < 4; r++)
            {
                for (int c = 0; c < nk; c++)
                {
                    key_schedule[r].Add(key_symbols[r + 4 * c]);
                }
            }


            for (int col = nk; col < nb * (nr + 1); col++)
            {
                List<byte> tmp = new List<byte>();
                if (col % nk == 0)
                {
                    for (int row = 1; row < 4; row++)
                    {
                        tmp.Add(key_schedule[row][col - 1]);
                    }
                    tmp.Add(key_schedule[0][col - 1]);

                    for (int j = 0; j < tmp.Count(); j++)
                    {
                        int sbox_row = tmp[j] / 0x10;
                        int sbox_col = tmp[j] % 0x10;
                        byte sbox_elem = sbox[16 * sbox_row + sbox_col];
                        tmp[j] = sbox_elem;
                    }

                    for (int row = 0; row < 4; row++)
                    {
                        byte s = (byte)((key_schedule[row][col - 4]) ^ (tmp[row]) ^ (rcon[row][col / nk - 1]));
                        key_schedule[row].Add(s);
                    }
                }
                else
                {
                    for (int row = 0; row < 4; row++)
                    {
                        byte s = (byte)((key_schedule[row][col - 4]) ^ key_schedule[row][col - 1]);
                        key_schedule[row].Add(s);
                    }
                }
            }

            return key_schedule;
        }

        static List<List<byte>> add_round_key(List<List<byte>> state, List<List<byte>> key_schedule, int round = 0)
        {
            for (int col = 0; col < nb; col++)
            {
                byte s0 = (byte)(state[0][col] ^ key_schedule[0][nb * round + col]);
                byte s1 = (byte)(state[1][col] ^ key_schedule[1][nb * round + col]);
                byte s2 = (byte)(state[2][col] ^ key_schedule[2][nb * round + col]);
                byte s3 = (byte)(state[3][col] ^ key_schedule[3][nb * round + col]);

                state[0][col] = s0;
                state[1][col] = s1;
                state[2][col] = s2;
                state[3][col] = s3;
            }

            return state;
        }

        static List<List<byte>> sub_bytes(List<List<byte>> state, bool inv = false)
        {
            List<byte> box;

            if (inv == false)   // шифрует, иначе дешифрует
                box = sbox;
            else
                box = inv_sbox;

            for (int i = 0; i < state.Count(); i++)
            {
                for (int j = 0; j < state[i].Count(); j++)
                {
                    int row = state[i][j] / 0x10;
                    int col = state[i][j] % 0x10;

                    byte box_elem = box[16 * row + col];
                    state[i][j] = box_elem;
                }
            }

            return state;
        }

        static List<List<byte>> shift_rows(List<List<byte>> state, bool inv = false)
        {
            int count = 1;

            if (inv == false) // шифрует, иначе дешифрует
            {
                for (int i = 1; i < nb; i++)
                {
                    state[i] = left_shift(state[i], count);
                    count++;
                }
            }
            else
            {
                for (int i = 1; i < nb; i++)
                {
                    state[i] = right_shift(state[i], count);
                    count++;
                }
            }

            return state;
        }

        static List<List<byte>> mix_columns(List<List<byte>> state, bool inv = false)
        {
            byte s0, s1, s2, s3;

            for (int i = 0; i < nb; i++)
            {
                if (inv == false) // шифрует, иначе дешифрует
                {
                    s0 = (byte)(mul_by_02(state[0][i]) ^ mul_by_03(state[1][i]) ^           state[2][i]  ^           state[3][i]);
                    s1 = (byte)(          state[0][i]  ^ mul_by_02(state[1][i]) ^ mul_by_03(state[2][i]) ^           state[3][i]);
                    s2 = (byte)(          state[0][i]  ^           state[1][i]  ^ mul_by_02(state[2][i]) ^ mul_by_03(state[3][i]));
                    s3 = (byte)(mul_by_03(state[0][i]) ^           state[1][i]  ^           state[2][i]  ^ mul_by_02(state[3][i]));
                }
                else
                {
                    s0 = (byte)(mul_by_0e(state[0][i]) ^ mul_by_0b(state[1][i]) ^ mul_by_0d(state[2][i]) ^ mul_by_09(state[3][i]));
                    s1 = (byte)(mul_by_09(state[0][i]) ^ mul_by_0e(state[1][i]) ^ mul_by_0b(state[2][i]) ^ mul_by_0d(state[3][i]));
                    s2 = (byte)(mul_by_0d(state[0][i]) ^ mul_by_09(state[1][i]) ^ mul_by_0e(state[2][i]) ^ mul_by_0b(state[3][i]));
                    s3 = (byte)(mul_by_0b(state[0][i]) ^ mul_by_0d(state[1][i]) ^ mul_by_09(state[2][i]) ^ mul_by_0e(state[3][i]));
                }

                state[0][i] = s0;
                state[1][i] = s1;
                state[2][i] = s2;
                state[3][i] = s3;
            }

            return state;
        }

        static List<T> left_shift<T>(List<T> list, int count)
        {
            List<T> res = list;

            for (int i = 0; i < count; i++)
            {
                List<T> tmp;
                tmp = res.GetRange(1, res.Count() - 1);
                tmp.Add(res[0]);
                res = tmp;
            }

            return res;
        }
       
        static List<T> right_shift<T>(List<T> list, int count)
        {
            List<T> res = list;

            for (int i = 0; i < count; i++)
            {
                List<T> tmp = new List<T>();
                tmp.Add(res.Last());
                tmp.AddRange(res.GetRange(0, res.Count() - 1));
                res = tmp;
            }

            return res;
        }

        static byte mul_by_02(byte num)
        {
            byte res;

            if (num < 0x80)
            {
                res = (byte)(num << 1);
            }
            else
            {
                res = (byte)((num << 1) ^ 0x1b);
            }

            return (byte)(res % 0x100);
        }

        static byte mul_by_03(byte num)
        {
            return (byte)(mul_by_02(num) ^ num);
        }

        static byte mul_by_09(byte num)
        {
            return (byte)(mul_by_02(mul_by_02(mul_by_02(num))) ^ num);
        }

        static byte mul_by_0b(byte num)
        {
            return (byte)(mul_by_02(mul_by_02(mul_by_02(num))) ^ mul_by_02(num) ^ num);
        }

        static byte mul_by_0d(byte num)
        {
            return (byte)(mul_by_02(mul_by_02(mul_by_02(num))) ^ mul_by_02(mul_by_02(num)) ^ num);
        }

        static byte mul_by_0e(byte num)
        {
            return (byte)(mul_by_02(mul_by_02(mul_by_02(num))) ^ mul_by_02(mul_by_02(num)) ^ mul_by_02(num)); 
        }
    }
}