#include<fstream>
#include<string>
#include<vector>
#include<iostream>
#include<Windows.h>
#include<algorithm>

bool frequencyChecker(std::string *s, std::string *search)
{
    //EDIT THIS TO CHANGE SEARCH FREQUENCY
    //MAKE IT A DECIMAL REPRESENTING A PERCENTAGE
    double percent = 0.9999;


    std::vector<std::string> list;
    std::string temp;
/*
    for(char ch : *search)
    {
        if (ch == '\0') break;
        if(ch != ' ')
        {
            temp += ch;
        }
        else//found a space
        {
            list.push_back(temp);
            temp = "";
        }
    }
    */
   int num = 0;
   for(char ch : *search)
   {
       if((num == 16) || (ch == ' '))
       {
           num = 0;
           list.push_back(temp);
       }
       else temp += ch;
       num++;
   }

    double count = 0;
    double i;

    for(i = 0; i < list.size(); i++)
    {
        std::size_t found = s->find(list[i]);
        if(found != std::string::npos)
        {
            count++;
        }
    }
    //std::cout << count;

    //calculating simalarity
    double h = count / i;
    //std::cout << h << std::endl;
    if( h >= percent)
    {
        std::cout << "Returning true due to found percentage of : " << h << std::endl;
        return true;
    }
    else return false;

}
//utility function to take the found file and search it for the string I want to find, then returns the directory
std::string stringFinder(std::string s, std::string search, int &count)
{
    std::ifstream FILE;

    FILE.open(s);

    if(!(FILE))
    {
        std::cout << "error reading file\ndirectory of false file: " << s << std::endl;
        return "";
    }
    //the file is open now; let's read it

    std::string line;

    count = 0;
    while(true)
    {
        getline(FILE, line);
        count ++;

        if(FILE.eof())
        {
            break;
        }
        
        std::transform(line.begin(), line.end(), line.begin(), ::tolower);

        //if(frequencyChecker(&s, &line)) return s;

        std::size_t found = line.find(search);

        if(found != std::string::npos)
        {
            //std::cout << search << std::endl;
            if(frequencyChecker(&s, &line)) return s;
            return s;
        }
       
    }

    FILE.close();
    return "";
}


void FindFile(const std::wstring &directory, std::string *searchKey, std::ofstream &OFILE)
{
    std::wstring tmp = directory + L"\\*";
    WIN32_FIND_DATAW file;
    HANDLE search_handle = FindFirstFileW(tmp.c_str(), &file);
    int count;
    if (search_handle != INVALID_HANDLE_VALUE)
    {
        std::vector<std::wstring> directories;

        do
        {
            if (file.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
            {
                if ((!lstrcmpW(file.cFileName, L".")) || (!lstrcmpW(file.cFileName, L"..")))
                    continue;
            }

            tmp = directory + L"\\" + std::wstring(file.cFileName);
            //std::wcout << tmp << std::endl;

            if (file.dwFileAttributes & FILE_ATTRIBUTE_DIRECTORY)
                directories.push_back(tmp);
            else
            {
                //converting wstring to normal string
                std::string dirOfFile(tmp.begin(), tmp.end());
                //std::cout << "Searching in: " << dirOfFile << std::endl;
                //calling the file reading function
                if((stringFinder(dirOfFile, *searchKey, count)) != "")
                {
                    OFILE << "Instance found on line " << count << " in:" << std::endl;
                    OFILE << dirOfFile << std::endl << std::endl;
                    std::cout << dirOfFile << std::endl;
                    //OFILE.close();
                }
            } 
        }
        while (FindNextFileW(search_handle, &file));

        FindClose(search_handle);

        for(std::vector<std::wstring>::iterator iter = directories.begin(), end = directories.end(); iter != end; ++iter)
            FindFile(*iter, searchKey, OFILE);
    }
}

int main()
{
    //auto start = std::chrono::high_resolution_clock::now;
    //std::wstring dir = "C:\Users\\Jason Erickson\\Desktop";
    //std::wstring dir;

    std::string searchKey = "water";

    //std::cout << "Enter the string you'd like to search for: ";
    //std::cin >> searchKey;

    //make the searchkey lowercase to make things non-case-sensitive
    std::transform(searchKey.begin(), searchKey.end(), searchKey.begin(), ::tolower);

    std::ofstream OFILE;
    OFILE.open("instances.txt");

    FindFile(L"C:\\Users\\drago\\Downloads\\shaders", &searchKey, OFILE);



    int a;
    //std::cin >> a;

    return 0;
}

