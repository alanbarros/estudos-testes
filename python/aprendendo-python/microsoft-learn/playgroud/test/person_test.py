import unittest
from ..person import Person

class TestPerson(unittest.TestCase):

    def test_create_person(self):
        name = "Jessica"
        age = 29
        person = Person(name, age)
        self.assertEqual(person.name, name)
        self.assertEqual(person.age, age)

if __name__ == '__main__':
    unittest.main()