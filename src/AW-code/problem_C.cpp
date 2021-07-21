#include <iostream>
#include <list>
#include <algorithm>

using namespace std;

//https://github.com/mbobesic/algorithms-playground/tree/master/kattis


class Node{
private:
    int node_ID;
    list <int> children_id;

public:

    void set_ID(int ID){
        node_ID = ID;
    }

    int get_ID(){
        return node_ID;
    }

    void push_child_ID(int ID){
        children_id.push_front(ID);
    }

    bool search_child_ID(int ID){
        return (find(children_id.begin(), children_id.end(), ID) != children_id.end());
    }

    void print_children_IDs(){
        for(auto i = children_id.begin(); i != children_id.end(); ++i){
            cout << *i << "\t";
        }
        cout << endl;
    }
};
/*
struct Node{
    int ID;
    Node *Children[];
};
*/


class Cases{
private:
    Node node_list[1000]; //17129
    int node_list_size = 1;

public:
    void add_node(int node_ID){
        node_list[node_list_size].set_ID(node_ID);
        node_list_size++;
    }

    void add_child(int node_ID, int childe_ID){
        for (int i = 1; i < node_list_size; i++){
            if(node_list[i].get_ID() == node_ID){
                node_list[i].push_child_ID(childe_ID);
                break;
            }
        }
    }

    void print_node(int node_ID){
        for (int i = 1; i < node_list_size; i++){
            if(node_list[i].get_ID() == node_ID){
                cout << node_list[i].get_ID() << ": ";
                node_list[i].print_children_IDs();
            }
        }

    }

    bool search_node_child(int node_ID, int child_ID){
        return node_list[node_ID].search_child_ID(child_ID);
    }
    
    int solve_case(){
        int missing_implications1 = 0;
        int missing_implications2 = 0;
        //cout << "node_list_size:\t" << node_list_size << endl;
        for(int i = 1; i < node_list_size; i++){
            //cout << "i:\t" << i << endl;
            //print_node(i);
            if(i == node_list_size-1){
                if(!search_node_child(i, 1)){
                    missing_implications1++;
                    //cout << "missing_implications1: \t" << missing_implications1<< endl;
                }
            } else{
                if(!search_node_child(i, i+1)){
                    missing_implications1++;
                    //cout << "missing_implications1: \t" << missing_implications1<< endl;
                }
            }
            if(i == node_list_size-1){
                if(!search_node_child(node_list_size-i, node_list_size-1)){
                    missing_implications2++;
                    //cout << "missing_implications1: \t" << missing_implications1<< endl;
                }
            } else{
                if(!search_node_child(node_list_size-i, node_list_size-i-1)){
                    missing_implications2++;
                    //cout << "missing_implications1: \t" << missing_implications1<< endl;
                }
            }


        }
        //cout << "missing_implications1: \t" << missing_implications1<< endl;
        //cout << "missing_implications2: \t" << missing_implications2<< endl;
        if(missing_implications1 <= missing_implications2){
            return missing_implications1;
        } else{
            return missing_implications2;
        }

    }
    
    
    int get_node_list_size(){
        return node_list_size;
    }
};
int main() {
    struct Node parent;
    int testcases;
    int number_of_statements;
    int proved_implications;
    int S1;
    int S2;
    Cases testcases_list[5];

    //cout << "Put the number of testcases" << endl;
    cin >> testcases;

    if (testcases <= 0 || testcases  > 100){
        cout << "The number of testcases is incorrect.\nNOTE! 0 < testcases ≤ 100" << endl;
    }

    for (int i = 1; i <= testcases; i++){
        //cout << "case:\t" << i << endl;
        //cout << "Put the numbers of statements (s) and proved implications (p) for case " << i << ": S P" << endl;
        cin >> number_of_statements >> proved_implications;
        if(number_of_statements < 1 || number_of_statements > 20000){
            cout << "wrong number of statement! (1≤S≤20000)" << endl;
            i--;
            continue;
        }
        if(proved_implications < 0 || proved_implications > 50000){
            cout << "Wrong number of proved implications! (0≤P≤50000).\n try again!" << endl;
            i--;
            continue;
        }

        for(int j = 1; j <= number_of_statements; j++){
            testcases_list[i].add_node(j);
        }
        for (int j = 1; j <= proved_implications; j++){
            //cout << "statements:\t" << j << endl;
            //cout << "Put both implied statements ID (S1 -> S2) for case(" << i << "), statement("<< j << "): S1 S2" << endl;
            cin >> S1 >> S2;
            if(S1 == S2 || S1 < 1 || S2 < 1 || S1 > number_of_statements || S2 > number_of_statements){
                cout << "Wrong statements IDs! (1≤s1,s2≤n and s1≠s2).\n try again!" << endl;
                i--;
                continue;
            }
            testcases_list[i].add_child(S1, S2);
        }

    }


    // solve

    for(int i = 1; i <= testcases; i++){
        //cout << "case: " << i << endl;
        cout << testcases_list[i].solve_case() << endl;/*
        for(int j = 1; j < testcases_list[i].get_node_list_size(); j++){
            testcases_list[i].print_node(j);
        }*/
    }
/*     int case_ID = 0;
    int node_ID;
    int child_ID;
    while(case_ID != -2){
        cout << "search children: input case, node, chile" << endl;
        cin >> case_ID >> node_ID >> child_ID;
        if(testcases_list[case_ID].search_node_child(node_ID, child_ID))
            cout << "found!" << endl;
    } */
    return 0;
}