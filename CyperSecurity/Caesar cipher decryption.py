def caesar_cipher_decrypt(cipher_text, shift_key):
    decrypted_text = ""
    for char in cipher_text:
        if char.isalpha():  # تأكد أن الحرف هو حرف أبجدي
            # التعامل مع الأحرف الكبيرة والصغيرة
            ascii_offset = 65 if char.isupper() else 97
            # فك التشفير باستخدام الإزاحة العكسية
            decrypted_char = chr((ord(char) - ascii_offset - shift_key) % 26 + ascii_offset)
            decrypted_text += decrypted_char
        else:
            # لو الحرف مش حرف (زي مسافة أو علامات ترقيم)، نضيفه كما هو
            decrypted_text += char
    return decrypted_text

# مثال
cipher_text = "Khoor Zruog!"  # النص المشفر
shift_key = 3  # المفتاح
print("Decrypted Text:", caesar_cipher_decrypt(cipher_text, shift_key))